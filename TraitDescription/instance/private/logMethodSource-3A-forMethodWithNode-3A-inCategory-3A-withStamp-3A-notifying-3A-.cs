logMethodSource: aText forMethodWithNode: aCompiledMethodWithNode inCategory: category withStamp: changeStamp notifying: requestor
	| priorMethodOrNil newText |
	priorMethodOrNil := self compiledMethodAt: aCompiledMethodWithNode selector ifAbsent: [].
	newText _ ((requestor == nil or: [requestor isKindOf: SyntaxError]) not
						and: [Preferences confirmFirstUseOfStyle])
			ifTrue: [aText askIfAddStyle: priorMethodOrNil req: requestor]
			ifFalse: [aText].
	aCompiledMethodWithNode method putSource: newText
		fromParseNode: aCompiledMethodWithNode node
		class: self category: category withStamp: changeStamp 
		inFile: 2 priorMethod: priorMethodOrNil.