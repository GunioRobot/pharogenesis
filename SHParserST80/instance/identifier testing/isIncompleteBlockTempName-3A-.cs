isIncompleteBlockTempName: aString 
	"Answer true if aString is the start of the name of a block temporary. false otherwise"

	| temp  |
	blockDepth to: 1 by: -1 do: [:level | 
		temp := (temporaries at: level ifAbsent: [#()]) anySatisfy: [:each | each beginsWith: aString].
		temp ifTrue: [^true]].
	^false