roundCornersOf: aMorph during: aBlock

	self flag: #roundedRudeness.	

	aMorph wantsRoundedCorners ifFalse:[^aBlock value].
	(self seesNothingOutside: (CornerRounder rectWithinCornersOf: aMorph bounds))
		ifTrue: ["Don't bother with corner logic if the region is inside them"
				^ aBlock value].
	CornerRounder roundCornersOf: aMorph on: self
		displayBlock: aBlock
		borderWidth: aMorph borderWidth
		corners: aMorph roundedCorners