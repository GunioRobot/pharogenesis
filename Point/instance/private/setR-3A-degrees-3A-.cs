setR: rho degrees: theta 

	| radians |
	radians _ theta asFloat degreesToRadians.
	x _ rho asFloat * radians cos.
	y _ rho asFloat * radians sin.