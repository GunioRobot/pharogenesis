asOctetStringText

	string class == MultiString ifTrue: [
		^ self class string: string asOctetString runs: self runs copy.
	].
	^self.
