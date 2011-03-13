destString: aString 
	realDst _ self split: aString asString.
	dstLines _ OrderedCollection new.
	dstMap _ OrderedCollection new.
	realDst
		doWithIndex: [:line :realIndex | 
			dstLines
				add: (self formatLine: line).
			dstMap add: realIndex].
	dstPos _ PluggableDictionary new: dstLines size.
	dstPos hashBlock: self stringHashBlock.
	dstLines
		doWithIndex: [:line :index | (dstPos includesKey: line)
				ifTrue: [(dstPos at: line)
						add: index.
					multipleMatches _ true]
				ifFalse: [dstPos
						at: line
						put: (OrderedCollection with: index)]]