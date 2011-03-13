createSound: id info: info
	| theSound loops |
	theSound := sounds at: id ifAbsent:[^nil].
	loops := info loopCount.
	loops <= 1 ifTrue:[^theSound].
	^RepeatingSound repeat: theSound count: loops