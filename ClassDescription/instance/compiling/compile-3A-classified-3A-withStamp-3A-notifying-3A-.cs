compile: text classified: category withStamp: changeStamp notifying: requestor 
	| selector priorMethod method methodNode newText |
	method _ self
		compile: text asString
		notifying: requestor
		trailer: #(0 0 0 0)
		ifFail: [^nil]
		elseSetSelectorAndNode: 
			[:sel :node | selector _ sel.
			priorMethod _ methodDict at: selector ifAbsent: [nil].
			methodNode _ node].
	self acceptsLoggingOfCompilation ifTrue:
		[newText _ (requestor ~~ nil and: [Preferences confirmFirstUseOfStyle])
			ifTrue: [text askIfAddStyle: priorMethod req: requestor]
			ifFalse: [text].
		 method putSource: newText
				fromParseNode: methodNode
				class: self category: category withStamp: changeStamp 
				inFile: 2 priorMethod: priorMethod].
	self organization classify: selector under: category.
	^selector