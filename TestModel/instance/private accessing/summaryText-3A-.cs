summaryText: aString

	(summaryText = aString)
		ifFalse: [
			summaryText := aString.
			self changed: #summaryText].