saveAsPrototype

	| m |
	m _ argument.
	(SelectionMenu confirm: 'Make this morph the prototype for ', m class printString, '?')
		ifFalse: [^ self].
	m class prototype: m.
