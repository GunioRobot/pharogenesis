allocateGETEntry: nSlots
	"Allocate n slots in the global edge table"
	| srcIndex dstIndex |
	self inline: false.
	"First allocate nSlots in the AET"
	(self allocateAETEntry: nSlots) ifFalse:[^false].
	self aetUsedGet = 0 ifFalse:["Then move the AET upwards"
		srcIndex _ self aetUsedGet.
		dstIndex _ self aetUsedGet + nSlots.
		1 to: self aetUsedGet do:[:i|
			aetBuffer at: (dstIndex _ dstIndex - 1) put: (aetBuffer at: (srcIndex _ srcIndex - 1))].
	].
	aetBuffer _ aetBuffer + nSlots.
	^true