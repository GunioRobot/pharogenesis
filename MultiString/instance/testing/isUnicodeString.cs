isUnicodeString

	self do: [:c |
		c isUnicode ifTrue: [
			^ true
		].
	].

	^ false.
