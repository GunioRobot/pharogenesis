makeResult: result for: index in: dispatcher
	"Answer Association if needed"

	| disp sym |
	disp := dispatcher at: index.
	disp size < 3 		"return result itself"
		ifTrue: [^result].
	sym := disp at: 3.
	sym = #->		"return selector -> result"
		 ifTrue: [^(disp at: 2) -> result].
	"return symbol -> result"
	^sym -> result