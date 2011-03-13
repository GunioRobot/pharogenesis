pcRange
	"Answer the indices in the source code for the method corresponding to  
	the selected context's program counter value."
	| i methodNode pc end |
	methodText isEmptyOrNil
		ifTrue: [^ 1 to: 0].
	sourceMap == nil
		ifTrue: [self selectedClass == nil
				ifTrue: [^ 1 to: 0].
			[[methodNode := self selectedClass compilerClass new
						parse: methodText
						in: self selectedClass
						notifying: self ]
				on: Warning
				do: [:ex | 
					methodText := ('(syntax error) ' , ex description , String cr , methodText) asText.
					ex return]]
				on: Error
				do: [:ex | 
					methodText := ('(parse error) ' , ex description , String cr , methodText) asText.
					ex return].
			methodNode
				ifNil: [sourceMap := nil.
					^ 1 to: 0].
			sourceMap := methodNode sourceMap].
	(sourceMap size = 0 or: [ selectedContext isDead ])
		ifTrue: [^ 1 to: 0].
	
	Smalltalk at: #RBProgramNode ifPresent:[:nodeClass|	
	 (methodNode isKindOf: #nodeClass) ifTrue: [
		pc _ stackListIndex = 1
			ifTrue: [selectedContext pc]
			ifFalse: [selectedContext previousPc].
		i _ sourceMap findLast: [:pcRange | pcRange key <= pc].
		i = 0 ifTrue:[^ 1 to: 0].
		^ (sourceMap at: i) value
	]].	
		
		
	pc := selectedContext pc.
	pc := pc - 2.
	i := sourceMap
				indexForInserting: (Association key: pc value: nil).
	i < 1
		ifTrue: [^ 1 to: 0].
	i > sourceMap size
		ifTrue: [end := sourceMap
						inject: 0
						into: [:prev :this | prev max: this value last].
			^ end + 1 to: end].
	^ (sourceMap at: i) value