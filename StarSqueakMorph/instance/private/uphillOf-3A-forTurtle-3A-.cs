uphillOf: patchVarName forTurtle: aTurtle 
	"Answer the heading the points in the direction of increasing value for the given patch variable. If there is no gradient, or if the turtle is outside the world bounds, answer the turtles current heading."

	| patchVar turtleX turtleY startX endX startY endY maxVal rowOffset thisVal maxValX maxValY |
	patchVar := patchVariables at: patchVarName ifAbsent: [^aTurtle heading].
	turtleX := aTurtle x truncated + 1.
	turtleY := aTurtle y truncated + 1.
	turtleX := turtleX max: 1.
	turtleY := turtleY max: 1.
	turtleX := turtleX min: dimensions x.
	turtleY := turtleY min: dimensions y.
	startX := turtleX - sniffRange max: 1.
	endX := turtleX + sniffRange min: dimensions x.
	startY := turtleY - sniffRange max: 1.
	endY := turtleY + sniffRange min: dimensions y.
	maxVal := patchVar at: (turtleY - 1) * dimensions x + turtleX.
	maxValX := nil.
	startY to: endY
		do: 
			[:y | 
			rowOffset := (y - 1) * dimensions x.
			startX to: endX
				do: 
					[:x | 
					thisVal := patchVar at: rowOffset + x.
					thisVal > maxVal 
						ifTrue: 
							[maxValX := x.
							maxValY := y.
							maxVal := thisVal]]].
	nil = maxValX ifTrue: [^aTurtle heading].
	^(((maxValX - turtleX) @ (maxValY - turtleY)) degrees + 90.0) \\ 360.0