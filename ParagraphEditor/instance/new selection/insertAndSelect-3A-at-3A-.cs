insertAndSelect: aString at: anInteger

	self replace: (anInteger to: anInteger - 1)
		with: (Text string: (' ' , aString)
					attributes: emphasisHere)
		and: [self selectAndScroll]