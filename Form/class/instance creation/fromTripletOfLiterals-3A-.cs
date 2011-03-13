fromTripletOfLiterals: aTriplet
	| extentDoublet offsetDoublet |
	extentDoublet _ aTriplet at: 1.
	offsetDoublet _ aTriplet at: 3.
	^ self extent: (extentDoublet at: 1) @ (extentDoublet at: 2) fromArray: (aTriplet at: 2) offset: ((offsetDoublet at: 1) @ (offsetDoublet at: 2))