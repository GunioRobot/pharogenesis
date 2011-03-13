saveAsPrototype
	(self confirm: 'Make this morph the prototype for ' translated, self class printString, '?')
		ifFalse: [^ self].
	self class prototype: self.
