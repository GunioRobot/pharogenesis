inputInterpreterClass
	| platformName osVersion encoding |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) 
		ifTrue: [^MacRomanInputInterpreter].
	platformName = 'Win32' ifTrue: [^WinKSX1001InputInterpreter].
	platformName = 'Mac OS' 
		ifTrue: 
			[('10*' match: SmalltalkImage current osVersion) 
				ifTrue: [^MacUnicodeInputInterpreter]
				ifFalse: [^WinKSX1001InputInterpreter]].
	platformName = 'unix' 
		ifTrue: 
			[encoding := X11Encoding encoding.
			(EUCJPTextConverter encodingNames includes: encoding) 
				ifTrue: [^MacRomanInputInterpreter].
			(UTF8TextConverter encodingNames includes: encoding) 
				ifTrue: [^MacRomanInputInterpreter].
			(ShiftJISTextConverter encodingNames includes: encoding) 
				ifTrue: [^MacRomanInputInterpreter]].
	^MacRomanInputInterpreter