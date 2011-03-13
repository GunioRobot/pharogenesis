orientationString 

	^ self orientedVertically
		ifTrue:	['<yes>vertical orientation']
		ifFalse:	['<no>vertical orientation']