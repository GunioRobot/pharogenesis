on: aStream
	super on: aStream.
	self doLog ifTrue:[log _ Transcript].
	fillStyles _ Dictionary new.
	lineStyles _ Dictionary new.
	shapes _ Dictionary new.
	player _ FlashPlayerMorph new.
	fonts _ Dictionary new.
	forms _ Dictionary new.
	sounds _ Dictionary new.
	buttons _ Dictionary new.
	spriteOwners _ IdentityDictionary new.
	stepTime _ 1000.
	frame _ 1.
	activeMorphs _ Dictionary new: 100.
	passiveMorphs _ Dictionary new: 100.
	self recordSolidFill: 1 color: Color black.
	compressionBounds _ (-16r7FFF asPoint) corner: (16r8000) asPoint.
	currentShape _ WriteStream on: (Array new: 5).
	pointList _ WriteStream on: (Array new: 100).
	leftFillList _ WriteStream on: (WordArray new: 100).
	rightFillList _ WriteStream on: (WordArray new: 100).
	lineStyleList _ WriteStream on: (WordArray new: 100).
	fillIndex0 _ fillIndex1 _ lineStyleIndex _ 0.
	streamingSound _ FlashStreamingSound new.