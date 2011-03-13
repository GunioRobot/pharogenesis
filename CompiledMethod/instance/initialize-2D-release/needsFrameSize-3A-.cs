needsFrameSize: newFrameSize
	"Set the largeFrameBit to accomodate the newFrameSize.
	NOTE: I think the >= below is overly cautious.
	Recompile the system with just > some day - DI 2/26/96"
	| largeFrameBit header |
	largeFrameBit _ 16r20000.
	(self numTemps + newFrameSize) >= LargeFrame
		ifTrue: [^self error: 'Cannot compile--stack including temps is too deep'].
	header _ self objectAt: 1.
	(header bitAnd: largeFrameBit) ~= 0
		ifTrue: [header _ header - largeFrameBit].
	self objectAt: 1 put: header
			+ ((self numTemps + newFrameSize) >= SmallFrame
					ifTrue: [largeFrameBit]
					ifFalse: [0])