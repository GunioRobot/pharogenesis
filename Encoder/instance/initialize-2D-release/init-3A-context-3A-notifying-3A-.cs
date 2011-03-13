init: aClass context: aContext notifying: req
	requestor := req.
	class := aClass.
	nTemps := 0.
	supered := false.
	self initScopeAndLiteralTables.
	class variablesAndOffsetsDo:
		[:variable "<String|CFieldDefinition>" :offset "<Integer|nil>" |
		offset isNil
			ifTrue: [scopeTable at: variable name put: (FieldNode new fieldDefinition: variable)]
			ifFalse: [scopeTable
						at: variable
						put: (offset >= 0
								ifTrue: [InstanceVariableNode new
											name: variable index: offset]
								ifFalse: [MaybeContextInstanceVariableNode new
											name: variable index: offset negated])]].
	aContext ~~ nil ifTrue:
		[| homeNode |
		 homeNode := self bindTemp: self doItInContextName.
		 "0th temp = aContext passed as arg"
		 aContext tempNames withIndexDo:
			[:variable :index|
			scopeTable
				at: variable
				put: (MessageAsTempNode new
						receiver: homeNode
						selector: #namedTempAt:
						arguments: (Array with: (self encodeLiteral: index))
						precedence: 3
						from: self)]].
	sourceRanges := Dictionary new: 32.
	globalSourceRanges := OrderedCollection new: 32