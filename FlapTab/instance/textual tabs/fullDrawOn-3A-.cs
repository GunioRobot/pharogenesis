fullDrawOn: aCanvas
	| aList |
	self isCurrentlyTextual ifFalse:
		[^ super fullDrawOn: aCanvas].
	aList _ self orientation == #vertical
		ifTrue:
			[edgeToAdhereTo == #right
				ifTrue:
					[#(1 2)]
				ifFalse:
					[#(3 4)]]
		ifFalse:
			[edgeToAdhereTo == #top
				ifTrue:
					[#(2 3)]
				ifFalse:
					[#(1 4)]].
	CornerRounder roundCornersOf: self on: aCanvas
					displayBlock: [self basicFullDrawOn: aCanvas]
					borderWidth: borderWidth
					corners: aList