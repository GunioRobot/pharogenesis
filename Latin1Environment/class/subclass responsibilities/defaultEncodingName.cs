defaultEncodingName
	| platformName osVersion |
	platformName := SmalltalkImage current platformName.
	osVersion := SmalltalkImage current  getSystemAttribute: 1002.
	(platformName = 'Win32' and: [osVersion = 'CE']) ifTrue: [^'utf-8' copy].
	(#('Win32' 'Mac OS' 'ZaurusOS') includes: platformName) 
		ifTrue: [^'iso8859-1' copy].
	(#('unix') includes: platformName) ifTrue: [^'iso8859-1' copy].
	^'mac-roman'