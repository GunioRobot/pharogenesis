untilEnd: aBlock displayingProgress: aString
	aString
		displayProgressAt: Sensor cursorPoint
		from: 0 to: self size
		during:
			[:bar |
			[self atEnd] whileFalse:
				[bar value: self position.
				aBlock value]].