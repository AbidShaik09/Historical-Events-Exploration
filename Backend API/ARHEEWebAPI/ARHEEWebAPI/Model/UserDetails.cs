using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ARHEEWebAPI.Model
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string username { get; set; }
        [Required]
        [StringLength(100)]
        public string password { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public int age { get; set; }
        [Required]
        public string gender { get; set; }

    }


public static class UserDetailsEndpoints
{
	public static void MapUserDetailsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/UserDetails").WithTags(nameof(UserDetails));

        group.MapGet("/", () =>
        {
            return new [] { new UserDetails() };
        })
        .WithName("GetAllUserDetails")
        .WithOpenApi();

        group.MapGet("/{id}", (int id) =>
        {
            //return new UserDetails { ID = id };
        })
        .WithName("GetUserDetailsById")
        .WithOpenApi();

        group.MapPut("/{id}", (int id, UserDetails input) =>
        {
            return TypedResults.NoContent();
        })
        .WithName("UpdateUserDetails")
        .WithOpenApi();

        group.MapPost("/", (UserDetails model) =>
        {
            //return TypedResults.Created($"/api/UserDetails/{model.ID}", model);
        })
        .WithName("CreateUserDetails")
        .WithOpenApi();

        group.MapDelete("/{id}", (int id) =>
        {
            //return TypedResults.Ok(new UserDetails { ID = id });
        })
        .WithName("DeleteUserDetails")
        .WithOpenApi();
    }
}}
