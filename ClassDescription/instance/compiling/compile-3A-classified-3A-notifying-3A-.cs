compile: text classified: category notifying: requestor 
	| selector dict priorMethod method |
	method _ self
		compile: text asString
		notifying: requestor
		trailer: #(0 0 0 )
		ifFail: [^nil]
		elseSetSelectorAndNode: 
			[:sel :node | selector _ sel.
			priorMethod _ methodDict at: selector ifAbsent: [nil]].
	(SourceFiles isNil or: [(SourceFiles at: 2) == nil])
		ifFalse: [self acceptsLoggingOfCompilation
					ifTrue:
						[method
						putSource: text asString
						class: self category: category
						inFile: 2 priorMethod: priorMethod]].
	self organization classify: selector under: category.
	^selector