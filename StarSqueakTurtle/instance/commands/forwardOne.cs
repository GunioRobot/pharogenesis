forwardOne
	"Move one turtle step in the direction of my heading."

	penDown ifTrue: [world setPatchColorAtX: x y: y to: color].
	x _ x + headingRadians cos.
	y _ y - headingRadians sin.
	x < 0.0 ifTrue: [x _ x + wrapX].
	y < 0.0 ifTrue: [y _ y + wrapY].
	x >= wrapX ifTrue: [x _ x - wrapX].
	y >= wrapY ifTrue: [y _ y - wrapY].
