scanVersionsOf: method class: class meta: meta
		category: category selector: selector
	| sources position prevPos prevFileIndex preamble tokens sourceFilesCopy |
	changeList _ OrderedCollection new.
	list _ OrderedCollection new.
	listIndex _ 0.
	position _ method filePosition.
	sourceFilesCopy _ SourceFiles collect:
		[:x | x isNil ifTrue: [ nil ]
				ifFalse: [x readOnlyCopy]].
	file _ sourceFilesCopy at: method fileIndex.
	[position notNil & file notNil]
		whileTrue:
		[file position: (0 max: position-150).  "Skip back to before the preamble"
		[file position < (position-1)]  "then pick it up from the front"
			whileTrue: [preamble _ file nextChunk].
		prevPos _ nil.
		(preamble at: (preamble findLast: [:c | c isAlphaNumeric]))
			isDigit  "Only tokenize if preamble ends with a digit"
			ifTrue: [tokens _ Scanner new scanTokens: preamble]
			ifFalse: [tokens _ Array new  "ie cant be back ref"].
		((tokens size between: 7 and: 8)
			and: [(tokens at: tokens size-5) = #methodsFor:])
			ifTrue:
				[prevPos _ tokens at: tokens size-2.
				prevPos = 0
					ifTrue: [prevPos _ nil] "Zero means no source"
					ifFalse: [prevFileIndex _ tokens last]].
		self addItem:
				(ChangeRecord new file: file position: position
					type: #method class: class name category: category meta: meta)
			text: class name , (meta ifTrue: [' class '] ifFalse: [' ']) , selector.
		position _ prevPos.
		prevPos notNil ifTrue:
			[file _ sourceFilesCopy at: prevFileIndex]].
	sourceFilesCopy do: [:x | x notNil ifTrue: [x close]].
	listSelections _ Array new: list size withAll: false