forwardOne
	"Move one turtle step in the direction of my heading."

	penDown ifTrue: [world setPatchColorAtX: x y: y to: color].
	x := x + headingRadians cos.
	y := y - headingRadians sin.
	x < 0.0 ifTrue: [x := x + wrapX].
	y < 0.0 ifTrue: [y := y + wrapY].
	x >= wrapX ifTrue: [x := x - wrapX].
	y >= wrapY ifTrue: [y := y - wrapY].
