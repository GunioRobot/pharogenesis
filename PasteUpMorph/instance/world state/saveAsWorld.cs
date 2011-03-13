saveAsWorld
	| worldName s |
	worldName := UIManager default
		request: 'Please give this world a name' translated
		initialAnswer: 'test'.
	worldName ifNil: [worldName := String new].
	((self class class includesSelector: worldName asSymbol) and:
		[(self confirm: 'OK to overwrite' translated, ' "' , worldName , '"?') not])
		ifTrue: [^ self].

	s := (String new: 1000) writeStream.
	s	nextPutAll: worldName; cr; tab;
		nextPutAll: '"' , self class name , ' ' , worldName, ' open"'; cr; cr; tab;
		nextPutAll: '^ '.
	self printConstructorOn: s indent: 0.
	s cr.

	self class class
		compile: s contents
		classified: 'examples'
		notifying: nil.