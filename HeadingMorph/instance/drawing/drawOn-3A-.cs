drawOn: aCanvas

	| x y r center box |
	super drawOn: aCanvas.
	box _ self innerBounds.
	1 to: 9 do: [:i |
		x _ box left + ((box width * i) // 10).
		aCanvas line: (x@box top) to: (x@(box bottom - 1)) color: 
Color black.
		y _ box top + ((box height * i) // 10).
		aCanvas line: (box left@y) to: ((box right - 1)@y) color: 
Color black].

	r _ ((box width asFloat * magnitude asFloat) / 2.0) - 1.0.
	center _ box center.
	self drawArrowFrom: center - (1@1)
		to: center + ((r * degrees degreesToRadians cos)@0) - (1@1)
		width: 3
		color: (Color red)
		on: aCanvas.
	self drawArrowFrom: center - (1@1)
		to: center + (0@(r * degrees degreesToRadians sin)) - (1@1)
		width: 3
		color: (Color red)
		on: aCanvas.
	self drawArrowFrom: center - (1@1)
		to: center + (Point r: r degrees: degrees) - (1@1)
		width: 3
		color: Color black
		on: aCanvas.
