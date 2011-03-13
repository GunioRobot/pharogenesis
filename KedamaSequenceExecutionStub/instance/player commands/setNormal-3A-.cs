setNormal: degrees

	| headingRadians |
	headingRadians _ ((90.0 - degrees) \\ 360.0) degreesToRadians.

	(turtles arrays at: 7) at: self index put: headingRadians.
