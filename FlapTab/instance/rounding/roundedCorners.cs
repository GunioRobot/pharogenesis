roundedCorners
	^self orientation == #vertical
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