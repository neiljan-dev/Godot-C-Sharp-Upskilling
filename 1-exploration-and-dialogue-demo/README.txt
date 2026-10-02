Repo 1 - Movements
Sept 30 - Oct 1, 2026


Basic Movements (Up, Down, Left, Right)
➤  Class Declaration:


public → accessible outside the class.
partial → allows the class to be split across multiple files (Godot uses this internally).
CharacterBody2D → inherits movement and collision behavior from Godot’s built-in node.


➤  Exported Variable                                                                                                                                         

[Export] → makes the variable editable in the Godot Inspector.                                                                                                     
200f → default value (the f suffix marks it as a float).


➤  Physics Process Method                                                                                                         
                                                                                                                         
_PhysicsProcess → runs every physics frame (fixed timestep).                                                     
double delta → time in seconds since the last physics frame; used for frame‑rate independent movement.


➤  Vector Direction

Vector2 → a structure that holds two values: X and Y.                                                                             
direction → variable used to store player input direction.  (variable)                                                            
Vector2.Zero → initializes the vector to (0,0) (no movement).


➤ Normalization                                                                                                                                
direction = direction.Normalized();
Why normalize? If you move diagonally, (1,-1) has a longer length than (1,0) or (0,-1). 
Normalized() shrinks it back to length 1, so diagonal movement isn’t faster than straight movement.


➤ MoveAndSlide() 
applies velocity while respecting collisions, automatically handles collisions and makes the character “slide” along walls instead of stopping dead. 


➤ Input Condition
Input.IsActionPressed(...) - returns true continuously as long as a button is held down 
Input.IsActionJustPressed(...) - returns true only on the single frame or physics tick when the button is first pressed down.                                                           
Input.IsActionJustReleased(...) - triggers only once on the single frame when the button is let go.

➤  Local Velocity Assignment
Vector2 velocity = Velocity;
Copies the node's current built-in Velocity into a local variable so it can be modified and faded out over time within the physics process loop.


➤  Smooth Deceleration (Friction)
velocity.MoveToward(Vector2.Zero, 800f * (float)delta);
This is a handy Godot vector method that smoothly reduces the character's or object's velocity toward Vector2.Zero (stopping completely). 
It acts as friction: when the player stops pressing movement keys, the object gracefully slides to a halt instead of instantly freezing in place.

Vector Syntax:
When called on a vector instance, it only takes 2 parameters:
velocity.MoveToward(Vector2 to, float delta);

to (Vector2): The target vector you want to reach (in this case, Vector2.Zero to stop moving).
delta (float): The maximum step size the vector can change by during this frame.


How the "From" value works:
In my code, because I wrote velocity.MoveToward(...), the from value is implicitly the current velocity vector itself. 
You do not need to pass it as a separate parameter. The method automatically reads the starting values from the vector it was called on.

➤ Collision Counting & Loops
for (int i = 0; i < GetSlideCollisionCount(); i++)
GetSlideCollisionCount()  returns the total number of physical contact points or collisions registered during the current frame.


➤ Implicit Typing & Collision Data Fetching
var collision = GetSlideCollision(i);
var  a keyword that lets the compiler automatically deduce the data type of the variable based on the assigned value.
GetSlideCollision(i)  retrieves detailed data about a specific collision index.


➤ Type Checking and Pattern Matching
if (collision.GetCollider() is CharacterBody2D pushableBox)
GetCollider()  fetches the actual node instance that was hit by the player.
is CharacterBody2D pushableBox  checks if the collider is of type CharacterBody2D; if true, it simultaneously casts it and stores it in a newly scoped local variable.


➤ Collision Normals & Force Direction
Vector2 pushDir = -collision.GetNormal();
GetNormal()  returns a directional vector pointing perpendicularly away from the surface that was hit.
- (minus prefix operator)  inverts the normal vector, flipping it to point outward from the player and into the hit object to establish the push vector.


Nodes Function Learned:
Sprite2D
CharacterBody2D
CollisionShape2D
CollisionPolygon2D
StaticBody2D
Area2D
TileMapLayer