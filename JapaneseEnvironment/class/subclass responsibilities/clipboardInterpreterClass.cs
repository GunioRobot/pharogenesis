clipboardInterpreterClass
	| platformName osVersion |
	platformName := SmalltalkImage current  platformName.
	osVersion := SmalltalkImage current  getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) 
		ifTrue: [^NoConversionClipboardInterpreter].
	platformName = 'Win32' ifTrue: [^WinShiftJISClipboardInterpreter].
	platformName = 'Mac OS' ifTrue: [^MacShiftJISClipboardInterpreter].
	^platformName = 'unix' 
		ifTrue: 
			[(ShiftJISTextConverter encodingNames includes: X11Encoding getEncoding) 
				ifTrue: [MacShiftJISClipboardInterpreter]
				ifFalse: [UnixJPClipboardInterpreter]]
		ifFalse: [ NoConversionClipboardInterpreter ]