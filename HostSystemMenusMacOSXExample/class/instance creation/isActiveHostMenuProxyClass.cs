isActiveHostMenuProxyClass
"Am I active?"
	^(SmalltalkImage current platformName  = 'Mac OS' and: [SmalltalkImage current  osVersion asInteger >= 1000])