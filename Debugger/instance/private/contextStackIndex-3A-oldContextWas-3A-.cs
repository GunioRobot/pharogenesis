contextStackIndex: anInteger oldContextWas: oldContext 
	"Change the context stack index to anInteger, perhaps in response to user selection."

	| newMethod |
	contextStackIndex := anInteger.
	anInteger = 0
		ifTrue: [currentCompiledMethod := theMethodNode := tempNames := sourceMap := contents := nil.
			self changed: #contextStackIndex.
			self decorateButtons.
			self contentsChanged.
			contextVariablesInspector object: nil.
			receiverInspector object: self receiver.
			^ self].
	(newMethod := oldContext == nil
					or: [oldContext method ~~ (currentCompiledMethod := self selectedContext method)])
		ifTrue: [tempNames := sourceMap := nil.
			theMethodNode := Preferences browseWithPrettyPrint
				ifTrue: [ 	self selectedContext methodNodeFormattedAndDecorated: Preferences colorWhenPrettyPrinting ]
				ifFalse: [	self selectedContext methodNode ].
			contents := self selectedMessage.
			self contentsChanged.
			self pcRange
			"will compute tempNamesunless noFrills"].
	self changed: #contextStackIndex.
	self decorateButtons.
	tempNames == nil
		ifTrue: [tempNames := self selectedClassOrMetaClass parserClass new parseArgsAndTemps: contents notifying: nil].
	contextVariablesInspector object: self selectedContext.
	receiverInspector object: self receiver.
	newMethod
		ifFalse: [self changed: #contentsSelection]