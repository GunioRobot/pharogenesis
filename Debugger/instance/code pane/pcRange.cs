pcRange
	"Answer the indices in the source code for the method corresponding to 
	the selected context's program counter value."

	| i methodNode pc end |
	(selectingPC and: [contextStackIndex ~= 0])
		ifFalse: [^1 to: 0].
	sourceMap == nil ifTrue:
		[methodNode _ self selectedClass compilerClass new
			parse: self selectedMessage
			in: self selectedClass
			notifying: nil.
		sourceMap _ methodNode sourceMap.
		tempNames _ methodNode tempNames.
		self selectedContext method cacheTempNames: tempNames].
	sourceMap size = 0 ifTrue: [^1 to: 0].
	pc_ self selectedContext pc -
		((externalInterrupt and: [contextStackIndex=1])
			ifTrue: [1]
			ifFalse: [2]).
	i _ sourceMap indexForInserting: (Association key: pc value: nil).
	i < 1 ifTrue: [^1 to: 0].
	i > sourceMap size
		ifTrue:
			[end _ sourceMap inject: 0 into:
				[:prev :this | prev max: this value last].
			^ end+1 to: end].
	^(sourceMap at: i) value