spanWorld
	| aPoint |
	aPoint _ (self world ifNil: [self currentWorld]) extent.
	(self orientation == #vertical)
		ifTrue:
			[referent height: aPoint y]
		ifFalse:
			[referent width: aPoint x] 