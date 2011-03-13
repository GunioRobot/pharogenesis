on: aStream
	super on: aStream.
	self doLog ifTrue:[log := Transcript].
	fillStyles := Dictionary new.
	lineStyles := Dictionary new.
	shapes := Dictionary new.
	player := FlashPlayerMorph new.
	fonts := Dictionary new.
	forms := Dictionary new.
	sounds := Dictionary new.
	buttons := Dictionary new.
	spriteOwners := IdentityDictionary new.
	stepTime := 1000.
	frame := 1.
	activeMorphs := Dictionary new: 100.
	passiveMorphs := Dictionary new: 100.
	self recordSolidFill: 1 color: Color black.
	compressionBounds := (-16r7FFF asPoint) corner: (16r8000) asPoint.
	currentShape := WriteStream on: (Array new: 5).
	pointList := WriteStream on: (Array new: 100).
	leftFillList := WriteStream on: (WordArray new: 100).
	rightFillList := WriteStream on: (WordArray new: 100).
	lineStyleList := WriteStream on: (WordArray new: 100).
	fillIndex0 := fillIndex1 := lineStyleIndex := 0.
	streamingSound := FlashStreamingSound new.