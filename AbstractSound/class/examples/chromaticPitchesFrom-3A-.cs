chromaticPitchesFrom: aPitch
	| pitch halfStep |
	pitch _ aPitch isNumber
			ifTrue: [aPitch]
			ifFalse: [self pitchForName: aPitch].
	halfStep _ self halfStep.
	pitch _ pitch / halfStep.
	^ (0 to: 14) collect: [:i | pitch _ pitch * halfStep]