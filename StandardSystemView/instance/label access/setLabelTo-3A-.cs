setLabelTo: aString 
	"Force aString to be the new label of the receiver, bypassing any logic about whether it is acceptable and about propagating information about the change."
	| oldRegion oldWidth |
	oldRegion _ self labelTextRegion.
	oldWidth _ self insetDisplayBox width.
	self label: aString.
	Display fill: ((oldRegion merge: self labelTextRegion) expandBy: 3@0)
			fillColor: self labelColor.
	self insetDisplayBox width = oldWidth
		ifTrue: [self displayLabelText; emphasizeLabel]
		ifFalse: [self uncacheBits; displayEmphasized].
