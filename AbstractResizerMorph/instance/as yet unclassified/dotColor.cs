dotColor

	^ dotColor ifNil: [self setDefaultColors. dotColor]