compressPoints: points
	"Compress the points using delta values and RLE compression."
	| lastPt runLength runValue nextPt deltaPt |
	points class == ShortPointArray 
		ifTrue:[stream print: points size]
		ifFalse:[points class == PointArray 
					ifTrue:[stream print: points size negated]
					ifFalse:[self error:'The point array has the wrong type!']].
	points size = 0 ifTrue:[^self].
	lastPt _ points at: 1.
	"First point has no delta"
	self printCompressedPoint: lastPt on: stream runLength: 1.
	runLength _ 0.
	runValue _ nil.
	2 to: points size do:[:i|
		nextPt _ points at: i.
		deltaPt _ nextPt - lastPt.
		runValue = deltaPt ifTrue:[
			runLength _ runLength + 1.
		]ifFalse:[
			self printCompressedPoint: runValue on: stream runLength: runLength.
			runValue _ deltaPt.
			runLength _ 1.
		].
		lastPt _ nextPt].
	runLength > 0 ifTrue:[self printCompressedPoint: runValue on: stream runLength: runLength].
	stream nextPut:$X."Terminating character"
	^stream