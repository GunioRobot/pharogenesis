chromaticPitchesFrom: aPitch

	| halfStep pitch |
	halfStep _ 2.0 raisedTo: (1.0 / 12.0).
	pitch _ aPitch isNumber
			ifTrue: [aPitch]
			ifFalse: [self pitchForName: aPitch].
	pitch _ pitch / halfStep.
	^ (0 to: 14) collect: [:i | pitch _ pitch * halfStep]
