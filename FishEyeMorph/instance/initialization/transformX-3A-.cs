transformX: aFloatArray
	| focus gridNum2 subArray dMaxX |

	focus _ srcExtent x asFloat / 2.

	gridNum2 _ (aFloatArray findFirst: [:x | x > focus]) - 1.

	dMaxX _ 0.0 - focus.
	subArray _ self g: (aFloatArray copyFrom: 1 to: gridNum2) max: dMaxX focus: focus.

	aFloatArray replaceFrom: 1 to: gridNum2 with: subArray startingAt: 1.


	dMaxX _ focus.    " = (size - focus)"
	subArray _ self g: (aFloatArray copyFrom: gridNum2 + 1 to: gridNum x + 1)
		max: dMaxX focus: focus.

	aFloatArray replaceFrom: gridNum2 + 1 to: gridNum x + 1 with: subArray startingAt: 1.
