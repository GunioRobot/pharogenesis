asOctetString

	| n |
	self isOctetString ifFalse: [
		self error: 'I have non-single byte character(s)'.
	].
	n _ String new: self size.
	1 to: self size do: [:i |
		n basicAt: i put: (self basicAt: i).
	].
	^ n.
