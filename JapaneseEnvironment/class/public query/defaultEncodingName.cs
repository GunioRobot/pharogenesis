defaultEncodingName
	| platformName osVersion |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) ifTrue: [^'utf-8'].
	(#('Win32' 'ZaurusOS') includes: platformName) ifTrue: [^'shift-jis'].
	platformName = 'Mac OS' 
		ifTrue: 
			[^('10*' match: SmalltalkImage current osVersion) 
				ifTrue: ['utf-8']
				ifFalse: ['shift-jis']].
	^'unix' = platformName ifTrue: ['euc-jp'] ifFalse: ['mac-roman']