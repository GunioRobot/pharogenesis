adjustPositionVisAVisFlap
	| sideToAlignTo opposite |
	opposite _ Utilities oppositeSideTo: edgeToAdhereTo.
	sideToAlignTo _ inboard
		ifTrue:	[opposite]
		ifFalse:	[edgeToAdhereTo].
	self perform: (Utilities simpleSetterFor: sideToAlignTo) with: (referent perform: opposite)