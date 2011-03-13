detailsText: aString

	(detailsText = aString)
		ifFalse: [
			detailsText := aString.
			self changed: #detailsText].