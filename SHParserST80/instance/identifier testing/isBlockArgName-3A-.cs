isBlockArgName: aString 
	"Answer true if aString is the name of a block argument, false otherwise"
	| temp arg |
	blockDepth to: 1 by: -1 do: [:level | 
		arg := (arguments at: level ifAbsent: [#()]) includes: aString.
		arg ifTrue: [^true].
		temp := (temporaries at: level ifAbsent: [#()]) includes: aString.
		temp ifTrue: [^false]].
	^false