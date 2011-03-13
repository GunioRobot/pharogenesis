testRemoveKeyifAbsent
	method properties at: #zork put: 'hello'.
	self assert: (method properties removeKey: #halt ifAbsent: [ 'hi' ]) = 'hi'.
	self assert: (method properties removeKey: #zork ifAbsent: [ 'hi' ]) = 'hello'.
	self assert: (self propertyDictionaryFor: method) isNil.
	self should: (method properties removeKey: #zork ifAbsent: [ 'hi' ]) = 'hi'.
	self assert: (self propertyDictionaryFor: method) isNil.