compressPoints: points
	"Compress the points using delta values and RLE compression."
	| lastPt runLength runValue nextPt deltaPt |
	points class == ShortPointArray 
		ifTrue:[stream print: points size]
		ifFalse:[points class == PointArray 
					ifTrue:[stream print: points size negated]
					ifFalse:[self error:'The point array has the wrong type!']].
	points size = 0 ifTrue:[^self].
	lastPt := points at: 1.
	"First point has no delta"
	self printCompressedPoint: lastPt on: stream runLength: 1.
	runLength := 0.
	runValue := nil.
	2 to: points size do:[:i|
		nextPt := points at: i.
		deltaPt := nextPt - lastPt.
		runValue = deltaPt ifTrue:[
			runLength := runLength + 1.
		]ifFalse:[
			self printCompressedPoint: runValue on: stream runLength: runLength.
			runValue := deltaPt.
			runLength := 1.
		].
		lastPt := nextPt].
	runLength > 0 ifTrue:[self printCompressedPoint: runValue on: stream runLength: runLength].
	stream nextPut:$X."Terminating character"
	^stream