sourceString: aString 
	realSrc _ self split: aString asString.
	srcLines _ OrderedCollection new.
	srcMap _ OrderedCollection new.
	realSrc
		doWithIndex: [:line :realIndex | 
			srcLines
				add: (self formatLine: line).
			srcMap add: realIndex].
	srcPos _ PluggableDictionary new: srcLines size.
	srcPos hashBlock: self stringHashBlock.
	srcLines
		doWithIndex: [:line :index | (srcPos includesKey: line)
				ifTrue: [(srcPos at: line)
						add: index.
					multipleMatches _ true]
				ifFalse: [srcPos
						at: line
						put: (OrderedCollection with: index)]]