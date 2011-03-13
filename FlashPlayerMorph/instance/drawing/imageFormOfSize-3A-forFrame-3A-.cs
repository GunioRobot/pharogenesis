imageFormOfSize: extentPoint forFrame: frameNr
	"Create an image of the given size for the given frame number"
	| thumbTransform form canvas morphsToDraw |
	thumbTransform := MatrixTransform2x3 
						transformFromLocal: localBounds 
						toGlobal: (0@0 extent: extentPoint).
	form := Form extent: extentPoint depth: 8.
	form fillColor: self color.
	canvas := BalloonCanvas on: form.
	canvas transformBy: thumbTransform.
	canvas aaLevel: (self defaultAALevel ifNil:[1]).
	canvas deferred: true.
	morphsToDraw := (submorphs select:[:m|
		m stepToFrame: frameNr.
		m visible]) sortBy:[:m1 :m2| m1 depth > m2 depth].
	morphsToDraw reverseDo:[:m|
		m fullDrawOn: canvas].
	submorphs do:[:m| m stepToFrame: frameNumber].
	canvas flush.
	^form