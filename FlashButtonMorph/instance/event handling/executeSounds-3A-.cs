executeSounds: type
	| sound |
	(sounds isNil or:[sounds isEmpty]) ifTrue:[^self].
	sound _ sounds at: type ifAbsent:[^self].
	sound isPlaying & false ifFalse:[sound play].