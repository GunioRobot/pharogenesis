when: anEventSymbol send: aSelector to: anObject
	self
		when: anEventSymbol
		perform: (MessageSend receiver: anObject selector: aSelector)