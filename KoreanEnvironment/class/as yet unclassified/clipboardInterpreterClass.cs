clipboardInterpreterClass
	| platformName osVersion |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) 
		ifTrue: [^NoConversionClipboardInterpreter].
	platformName = 'Win32' ifTrue: [^WinKSX1001ClipboardInterpreter].
	platformName = 'Mac OS' 
		ifTrue: 
			[('10*' match: SmalltalkImage current osVersion) 
				ifTrue: [^NoConversionClipboardInterpreter]
				ifFalse: [^WinKSX1001ClipboardInterpreter]].
	platformName = 'unix' 
		ifTrue: 
			[(ShiftJISTextConverter encodingNames includes: X11Encoding getEncoding) 
				ifTrue: [^WinKSX1001ClipboardInterpreter]
				ifFalse: [^NoConversionClipboardInterpreter]].
	^NoConversionClipboardInterpreter