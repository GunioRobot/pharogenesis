turtleCountHere
	"Answer a collection of turtles at this turtle's current location, including this turtle itself."

	| n |
	n := 0.
	world turtlesAtX: x y: y do: [:t | n := n + 1].
	^ n
