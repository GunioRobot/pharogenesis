printString
	"Answer an emphasized string in case of a breakpoint method"

	^self method hasBreakpoint
		ifTrue:[(super printString , ' [break]') asText allBold]
		ifFalse:[super printString]