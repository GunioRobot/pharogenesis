primLoadIndexArrayInto: dstArray startingAt: dstStart from: idxArray count: count max: maxValue offset: vtxOffset
	"Primitive. Load the given index array into the receiver.
	NOTE: dstStart is a zero-based index."
	| idx |
	<primitive:'b3dLoadIndexArray' module:'Squeak3D'>
	"self flag: #b3dDebug.	self primitiveFailed."
	1 to: count do:[:i|
		idx _ idxArray basicAt: i.
		(idx < 1 or:[idx > maxValue]) ifTrue:[^self error:'Index out of range'].
		dstArray at: dstStart + i put: idx + vtxOffset.
	].
	^count