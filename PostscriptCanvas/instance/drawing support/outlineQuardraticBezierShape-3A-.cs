outlineQuardraticBezierShape:vertices
	target moveto:(vertices at:1).
	3 to:vertices size by:3 do:[ :i |
		target curvetoQuadratic:(vertices at:i) from:(vertices at:i-2) via:(vertices at:i-1)	
	].
	target closepath.
