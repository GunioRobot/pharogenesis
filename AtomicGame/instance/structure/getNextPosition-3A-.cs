getNextPosition: aDirection 
	| currentPosition delta morph |
	currentPosition _ selected position.
	delta _ currentMap atomSize  * aDirection.
	[morph _ self somethingAt: currentPosition + delta.
	morph isNil]
		whileTrue: [currentPosition _ currentPosition + delta].
	^ currentPosition