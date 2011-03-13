incrementPatchVariable: patchVarName atX: xPos y: yPos by: amount
	"Increment the value of the given patch variable at the given location by the given amount. Do nothing if the location is out of bounds."

	| x y i var |
	x := xPos truncated.
	y := yPos truncated.
	((x < 0) or: [y < 0]) ifTrue: [^ self].
	((x >= dimensions x) or: [y >= dimensions y]) ifTrue: [^ self].
	i := ((y * dimensions x) + x) truncated + 1.
	var := patchVariables at: patchVarName ifAbsent: [^ self].
	var at: i put: ((var at: i) + amount).
