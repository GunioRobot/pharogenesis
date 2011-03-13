insertTab
	| aString aColor |
	aString _ FillInTheBlank request: 'Tab Name?' initialAnswer: 'New Tab'.
	aString size == 0 ifTrue: [^ self].
	aColor _ Color fromUser.
	self addTabNamed: aString color: aColor atIndex: (pages indexOf: currentPage)