setR: rho degrees: theta

	| radians |
	radians _ theta asFloat degreesToRadians.
	x _ (rho asFloat * radians cos) asInteger.
	y _ (rho asFloat * radians sin) asInteger.