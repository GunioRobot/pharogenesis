isUnicodeStringWithCJK

	self do: [:c |
		(c isUnicode and: [Unicode isUnifiedKanji: c charCode]) ifTrue: [
			^ true
		].
	].

	^ false.
