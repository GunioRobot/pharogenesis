inputInterpreterClass
	| platformName osVersion encoding |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) 
		ifTrue: [^MacRomanInputInterpreter].
	platformName = 'Win32' ifTrue: [^WinShiftJISInputInterpreter].
	platformName = 'Mac OS' 
		ifTrue: 
			[^('10*' match: SmalltalkImage current osVersion) 
				ifTrue: [MacUnicodeInputInterpreter]
				ifFalse: [MacShiftJISInputInterpreter]].
	platformName = 'unix' 
		ifTrue: 
			[encoding := X11Encoding encoding.
			(EUCJPTextConverter encodingNames includes: encoding) 
				ifTrue: [^UnixEUCJPInputInterpreter].
			(UTF8TextConverter encodingNames includes: encoding) 
				ifTrue: [^UnixUTF8JPInputInterpreter].
			(ShiftJISTextConverter encodingNames includes: encoding) 
				ifTrue: [^MacShiftJISInputInterpreter]].
	^MacRomanInputInterpreter