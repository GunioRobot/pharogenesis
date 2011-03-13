turn: degrees
	degrees ifNotNil:
		[self setHeading: (self getHeading + degrees asFloat) \\ 360.0]
