guessDefaultLineEndConvention

	"Lets try to guess the line end convention from what we know about the path name delimiter from FileDirectory."
	FileDirectory pathNameDelimiter = $: ifTrue:[^self defaultToCR].
	FileDirectory pathNameDelimiter = $/ ifTrue:[^self defaultToLF].
	FileDirectory pathNameDelimiter = $\ ifTrue:[^self defaultToCRLF].
	"in case we don't know"
	^self defaultToCR.
