orientation
	^ (#(left right) includes: edgeToAdhereTo)
		ifTrue:		[#vertical]
		ifFalse:		[#horizontal]