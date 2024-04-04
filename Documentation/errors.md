## Step 12 in mvc tutorial
Where are we making reference to the database entity?

Because if I assing a type that is not a model, it throw error, but it says nothing
if it is not referencing the name of an entity

```cs
// public DbSet< MOST BE A MODEL> Users {get; set;}
public DbSet<User> Users {get; set;}
```