isBlockTempName: aString 
	"Answer true if aString is the name of a block temporary. false otherwise"

	| temp arg |
	blockDepth to: 1 by: -1 do: [:level | 
		arg := (arguments at: level ifAbsent: [#()]) includes: aString.
		arg ifTrue: [^false].
		temp := (temporaries at: level ifAbsent: [#()]) includes: aString.
		temp ifTrue: [^true]].
	^false