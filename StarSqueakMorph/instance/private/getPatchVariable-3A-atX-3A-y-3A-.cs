getPatchVariable: patchVarName atX: xPos y: yPos
	"Answer the value of the given patch variable at the given turtle. Answer zero if the turtle is out of bounds."

	| x y i |
	x _ xPos truncated.
	y _ yPos truncated.
	((x < 0) or: [y < 0]) ifTrue: [^ 0].
	((x >= dimensions x) or: [y >= dimensions y]) ifTrue: [^ 0].
	i _ ((y * dimensions x) + x) truncated + 1.
	^ (patchVariables at: patchVarName ifAbsent: [^ 0]) at: i
