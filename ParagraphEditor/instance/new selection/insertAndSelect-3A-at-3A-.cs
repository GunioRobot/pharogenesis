insertAndSelect: aString at: anInteger

	self replace: (anInteger to: anInteger - 1)
		with: (' ' , aString) asText
		and: [self selectAndScroll]