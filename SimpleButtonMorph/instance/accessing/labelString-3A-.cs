labelString: aString

	| existingLabel |
	(existingLabel _ self findA: StringMorph)
		ifNil:
			[self label: aString]
		ifNotNil:
			[existingLabel contents: aString.
			self fitContents]
