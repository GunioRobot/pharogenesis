systemConverterClass
	| platformName osVersion encoding |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) 
		ifTrue: [^UTF8TextConverter].
	(#('Win32' 'ZaurusOS') includes: platformName) 
		ifTrue: [^ShiftJISTextConverter].
	platformName = 'Mac OS' 
		ifTrue: 
			[^('10*' match: SmalltalkImage current osVersion) 
				ifTrue: [UTF8TextConverter]
				ifFalse: [ShiftJISTextConverter]].
	platformName = 'unix' 
		ifTrue: 
			[encoding := X11Encoding encoding.
			encoding ifNil: [^EUCJPTextConverter].
			(encoding = 'utf-8') 
				ifTrue: [^UTF8TextConverter].				
			(encoding = 'shiftjis' | encoding = 'sjis') 
				ifTrue: [^ShiftJISTextConverter].				
			^EUCJPTextConverter].
	^MacRomanTextConverter