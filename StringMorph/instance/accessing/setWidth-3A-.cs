setWidth: width

	| f |
	f _ font ifNil: [TextStyle default fontAt: 1].
	self extent: width @ f height.
