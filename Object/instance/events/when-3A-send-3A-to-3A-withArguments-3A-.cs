when: anEventSymbol send: aSelector to: anObject withArguments: anArray
	self
		when: anEventSymbol
		perform: (MessageSend receiver: anObject selector: aSelector arguments: anArray)