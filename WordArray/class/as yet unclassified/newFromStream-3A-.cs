newFromStream: s
	| len |
	s next = 16r80 ifTrue:
		["A compressed format.  Could copy what BitMap does, or use a 
		special sound compression format.  Callers normally compress their own way."
		^ self error: 'not implemented'].
	s skip: -1.
	len _ s nextInt32.
	^ s nextWordsInto: (self new: len)