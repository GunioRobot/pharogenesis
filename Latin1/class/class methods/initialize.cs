initialize
"
	self initialize
"


	CompoundTextSequence _ String streamContents: [:s |
		s nextPut: (Character value: 27).
		s nextPut: $(.
		s nextPut: $B.
	].

	RightHalfSequence _ String streamContents: [:s |
		s nextPut: (Character value: 27).
		s nextPut: $-.
		s nextPut: $A.
	].
