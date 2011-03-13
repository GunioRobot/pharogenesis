baseNameFor: fileName
	"Return the given file name without its extension, if any."

	| delim i |
	delim _ DirectoryClass extensionDelimiter.
	i _ fileName findLast: [:c | c = delim].
	i = 0
		ifTrue: [^ fileName]
		ifFalse: [^ fileName copyFrom: 1 to: i - 1].
