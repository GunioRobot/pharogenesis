expandedFormat

	^ Preferences expandedPublishing
			or: [self valueOfProperty: #expandedFormat ifAbsent: [false]]
