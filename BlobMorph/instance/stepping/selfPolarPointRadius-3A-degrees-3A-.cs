selfPolarPointRadius: rho degrees: theta
	" Same as Point>>#r:degrees: in Point class except that x and y are not truncated to integers "
	| radians x y |

	radians _ theta asFloat degreesToRadians.
	x _ rho asFloat * radians cos.
	y _ rho asFloat * radians sin.
	^ Point x: x y: y