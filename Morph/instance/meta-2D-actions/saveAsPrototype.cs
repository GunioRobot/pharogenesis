saveAsPrototype
	(SelectionMenu confirm: 'Make this morph the prototype for ', self class printString, '?')
		ifFalse: [^ self].
	self class prototype: self.
