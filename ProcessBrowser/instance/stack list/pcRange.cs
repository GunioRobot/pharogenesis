pcRange
	"Answer the indices in the source code for the method corresponding to  
	the selected context's program counter value."
	| i methodNode pc end tempNames |
	methodText isEmptyOrNil
		ifTrue: [^ 1 to: 0].
	sourceMap == nil
		ifTrue: [self selectedClass == #unknown
				ifTrue: [^ 1 to: 0].
			[[methodNode _ self selectedClass compilerClass new
						parse: methodText
						in: self selectedClass
						notifying: self ]
				on: Warning
				do: [:ex | 
					methodText _ ('(syntax error) ' , ex description , String cr , methodText) asText.
					ex return]]
				on: Error
				do: [:ex | 
					methodText _ ('(parse error) ' , ex description , String cr , methodText) asText.
					ex return].
			methodNode
				ifNil: [sourceMap _ nil.
					^ 1 to: 0].
			sourceMap _ methodNode sourceMap.
			tempNames _ methodNode tempNames.
			selectedContext method cacheTempNames: tempNames].
	(sourceMap size = 0 or: [ selectedContext isDead ])
		ifTrue: [^ 1 to: 0].
	pc _ selectedContext pc.
	pc _ pc - 2.
	i _ sourceMap
				indexForInserting: (Association key: pc value: nil).
	i < 1
		ifTrue: [^ 1 to: 0].
	i > sourceMap size
		ifTrue: [end _ sourceMap
						inject: 0
						into: [:prev :this | prev max: this value last].
			^ end + 1 to: end].
	^ (sourceMap at: i) value