outlinePolygon:vertices
	target moveto:(vertices at:1).
	2 to:vertices size  do:[ :i |
		target lineto:(vertices at:i)	
	].
	target closepath.
