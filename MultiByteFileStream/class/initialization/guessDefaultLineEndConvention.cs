guessDefaultLineEndConvention

	"Lets try to guess the line end convention from what we know about the path name delimiter from FileDirectory."
	FileDirectory pathNameDelimiter = $: ifTrue:[^self defaultToCR].
	FileDirectory pathNameDelimiter = $/ 
		ifTrue:[((SmalltalkImage current getSystemAttribute: 1002)
			beginsWith: 'darwin')
				ifTrue: [^ self defaultToCR]
				ifFalse: [^ self defaultToLF]].
	FileDirectory pathNameDelimiter = $\ ifTrue:[^self defaultToCRLF].
	"in case we don't know"
	^self defaultToCR.
