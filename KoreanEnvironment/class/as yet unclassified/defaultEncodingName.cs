defaultEncodingName
	| platformName osVersion |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) ifTrue: [^'utf-8' copy].
	(#('Win32' 'ZaurusOS') includes: platformName) 
		ifTrue: [^'euc-kr' copy].
	platformName = 'Mac OS'
		ifTrue: [^ ('10*' match: SmalltalkImage current osVersion)
				ifTrue: ['utf-8']
				ifFalse: ['euc-kr']].
	(#('unix') includes: platformName) ifTrue: [^'euc-kr' copy].
	^'mac-roman'