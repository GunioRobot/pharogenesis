turtleCountHere
	"Answer a collection of turtles at this turtle's current location, including this turtle itself."

	| n |
	n _ 0.
	world turtlesAtX: x y: y do: [:t | n _ n + 1].
	^ n
