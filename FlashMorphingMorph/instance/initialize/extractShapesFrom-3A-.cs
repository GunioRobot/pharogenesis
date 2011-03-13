extractShapesFrom: aMorph
	| shapes |
	shapes := WriteStream on: Array new.
	aMorph allMorphsDo:[:m|
		(m isFlashMorph and:[m isFlashShape])
			ifTrue:[shapes nextPut: m shape].
	].
	^shapes contents.
