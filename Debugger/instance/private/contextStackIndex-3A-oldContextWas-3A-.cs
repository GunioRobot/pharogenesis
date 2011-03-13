contextStackIndex: anInteger oldContextWas: oldContext

	| newMethod |
	contextStackIndex _ anInteger.
	anInteger = 0
		ifTrue:
			[tempNames _ sourceMap _ contents _ nil.
			self changed: #contextStackIndex.
			self changed: #contents.
			contextVariablesInspector object: nil.
			receiverInspector object: self receiver.
			^self].
	(newMethod _ oldContext == nil or:
		[oldContext method ~~ self selectedContext method])
		ifTrue:
			[tempNames _ sourceMap _ nil.
			contents _ self selectedContext sourceCode.
			self changed: #contents.
			self pcRange "will compute tempNamesunless noFrills"].
	self changed: #contextStackIndex.
	tempNames == nil
		ifTrue: [tempNames _ 
					self selectedClassOrMetaClass parserClass new parseArgsAndTemps: contents notifying: nil].
	contextVariablesInspector object: self selectedContext.
	receiverInspector object: self receiver.
	newMethod ifFalse: [self changed: #pc]