﻿using EFCoreValueObjectPredicateExample;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

// Create
Console.WriteLine("Inserting a new blog");
db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();

// Read
Console.WriteLine("Querying for a blog");
var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();

// Update
Console.WriteLine("Updating the blog and adding a post");
blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!", Status = Status.Active });
db.SaveChanges();

// Query Using deep comparison
Console.WriteLine("This works: Querying for a post (Using deep comparison)");
var posts1 = db.Posts
    .Where(p => p.Status.Name.Equals(Status.Active.Name)).ToList();

// Query Using Value Object
Console.WriteLine("THIS BREAKS! Querying for a post (Using Value Object)");
var posts2 = db.Posts
    .Where(p => p.Status.Equals(Status.Active)).ToList();

// Delete
Console.WriteLine("Delete the blog");
db.Remove(blog);
db.SaveChanges();