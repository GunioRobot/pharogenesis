saveAsWorld
	| worldName s |
	worldName _ FillInTheBlank
		request: 'Please give this world a name'
		initialAnswer: 'test'.
	((self class class includesSelector: worldName asSymbol) and:
		[(PopUpMenu confirm: 'OK to overwrite ' , worldName , '?') not])
		ifTrue: [^ self].

	s _ WriteStream on: (String new: 1000).
	s	nextPutAll: worldName; cr; tab;
		nextPutAll: '"' , self class name , ' ' , worldName, ' open"'; cr; cr; tab;
		nextPutAll: '^ '.
	self printConstructorOn: s indent: 0.
	s cr.

	self class class
		compile: s contents
		classified: 'examples'
		notifying: nil.