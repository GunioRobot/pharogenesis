open: fileName forWrite: writeMode 
	| result |
	result := super open: fileName forWrite: writeMode.
	result ifNotNil: 
			[converter ifNil: 
					[self localName = (FileDirectory localNameFor: SmalltalkImage current sourcesName) 
						ifTrue: [converter := MacRomanTextConverter new]
						ifFalse: [converter := UTF8TextConverter new]].
			self detectLineEndConvention].
	^result