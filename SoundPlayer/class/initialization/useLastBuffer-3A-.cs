useLastBuffer: aBool
	Buffer ifNil:[^self].
	aBool 
		ifTrue:[LastBuffer _ SoundBuffer basicNew: Buffer basicSize]
		ifFalse:[LastBuffer _ nil]	