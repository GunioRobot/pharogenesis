when: anEventSymbol send: aSelector to: anObject with: anArgument
	self
		when: anEventSymbol
		perform: (MessageSend receiver: anObject selector: aSelector argument: anArgument)