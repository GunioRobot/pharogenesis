cCode: codeString inSmalltalk: aBlock
	"Support for Smalltalk-to-C translation. The given string is output literally when generating C code. If this code is being simulated in Smalltalk, answer the result of evaluating the given block."

	^ aBlock value
