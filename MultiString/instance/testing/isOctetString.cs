isOctetString

	1 to: self size do: [:pos |
		(self basicAt: pos) >= 256 ifTrue: [^ false].
	].
	^ true.
