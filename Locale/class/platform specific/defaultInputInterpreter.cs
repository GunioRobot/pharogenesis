defaultInputInterpreter
	| platformName osVersion |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) 
		ifTrue: [^NoInputInterpreter new].
	platformName = 'Win32' ifTrue: [^MacRomanInputInterpreter new].
	^NoInputInterpreter new