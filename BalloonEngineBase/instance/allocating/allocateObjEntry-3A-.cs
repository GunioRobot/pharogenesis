allocateObjEntry: nSlots
	"Allocate n slots in the object buffer"
	| srcIndex dstIndex |
	self inline: false.
	"First allocate nSlots in the GET"
	(self allocateGETEntry: nSlots) ifFalse:[^false].
	self getUsedGet = 0 ifFalse:["Then move the GET upwards"
		srcIndex _ self getUsedGet.
		dstIndex _ self getUsedGet + nSlots.
		1 to: self getUsedGet do:[:i|
			getBuffer at: (dstIndex _ dstIndex - 1) put: (getBuffer at: (srcIndex _ srcIndex - 1))].
	].
	getBuffer _ getBuffer + nSlots.
	^true