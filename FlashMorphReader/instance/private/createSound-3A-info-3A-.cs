createSound: id info: info
	| theSound loops |
	theSound _ sounds at: id ifAbsent:[^nil].
	loops _ info loopCount.
	loops <= 1 ifTrue:[^theSound].
	^RepeatingSound repeat: theSound count: loops