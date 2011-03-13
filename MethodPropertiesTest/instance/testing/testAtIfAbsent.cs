testAtIfAbsent
	self assert: (method properties at: #zork ifAbsent: [ 'hello' ]) = 'hello'.
	self assert: (self propertyDictionaryFor: method) isNil.
	method properties at: #zork put: 'hi'.
	self assert: (method properties at: #zork ifAbsent: [ 'hello' ]) = 'hi'.