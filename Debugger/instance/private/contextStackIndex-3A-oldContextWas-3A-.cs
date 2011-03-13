contextStackIndex: anInteger oldContextWas: oldContext 
	"Change the context stack index to anInteger, perhaps in response to user selection."

	| newMethod c |
	contextStackIndex := anInteger.
	anInteger = 0
		ifTrue: [currentCompiledMethod := theMethodNode := tempNames := sourceMap := contents := nil.
			self changed: #contextStackIndex.
			self decorateButtons.
			self contentsChanged.
			contextVariablesInspector object: nil.
			self receiverInspectorObject: self receiver context: nil.
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
	contextVariablesInspector object: (c _ self selectedContext).
	self receiverInspectorObject: self receiver context: c.
	newMethod
		ifFalse: [self changed: #contentsSelection]