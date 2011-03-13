setPatchVariable: patchVarName atX: xPos y: yPos to: newValue
	"Set the value of the given patch variable below the given turtle to the given value. Do nothing if the turtle is out of bounds."

	| x y i var |
	x := xPos truncated.
	y := yPos truncated.
	((x < 0) or: [y < 0]) ifTrue: [^ self].
	((x >= dimensions x) or: [y >= dimensions y]) ifTrue: [^ self].
	i := ((y * dimensions x) + x) truncated + 1.
	var := patchVariables at: patchVarName ifAbsent: [^ self].
	var at: i put: newValue.
