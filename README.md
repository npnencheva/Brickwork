# Brickwork Task written in C#

The builders must cover a rectangular area of size M × N ( M and N are even numbers)
with two layers of bricks that are rectangles of size 1 × 2. The first layer of the bricks has
already been completed. The second layer (in an effort to make the brickwork really
strong) must be created in a way that no brick in it lies exactly on a brick from the first
layer. However, it is allowed half of the same brick to lie on the same brick on the second
layer.
Create a console app that accepts input parameters for the given layout of the bricks for
the first layer, determine the possible layout of the second one, or prove that it is
impossible to create the second layer and print it in the console.

Input
1. N , M — dimensions of the area (both layers’ dimension a.k.a wall thickness/width
and length).
2. Then, add a single value separated by a space for each line N and following
column M describing the bricks layout in the first layer.

Assessment 
1. If the solution exists, write N lines with M numbers each that describe the layout of
the second layer in the way shown above.
2. Print output `-1` with a message that no solution exists.
3. Validations - N and M should define a valid area of less than 100 lines/ columns.
Validate input has exactly that number of rows and columns. Validate there are no
bricks spanning 3 rows/ columns.
4. Add comments on each class, method, and instantiated variable.
5. Surround each brick of the second layer with asterisk and/ or dash symbo

