adjustPositionVisAVisFlap
	| sideToAlignTo opposite |
	opposite := Utilities oppositeSideTo: edgeToAdhereTo.
	sideToAlignTo := inboard
		ifTrue:	[opposite]
		ifFalse:	[edgeToAdhereTo].
	self perform: (Utilities simpleSetterFor: sideToAlignTo) with: (referent perform: opposite)