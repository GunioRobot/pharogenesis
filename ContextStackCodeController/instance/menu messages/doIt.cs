doIt

	| result |
	result _ super doIt.
	result ~~ #failedDoit ifTrue: [model proceedValue: result].
	^result