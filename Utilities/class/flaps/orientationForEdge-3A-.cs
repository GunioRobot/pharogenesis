orientationForEdge: anEdge
	^ (#(left right) includes: anEdge)
		ifTrue:	[#vertical]
		ifFalse:	[#horizontal]