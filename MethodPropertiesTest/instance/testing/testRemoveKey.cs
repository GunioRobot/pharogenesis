testRemoveKey
	method properties at: #zork put: 'hello'.
	self should: [ method properties removeKey: #halt ] raise: Error.
	self assert: (method properties removeKey: #zork) = 'hello'.
	self assert: (self propertyDictionaryFor: method) isNil.
	self should: [ method properties removeKey: #zork ] raise: Error.
	self assert: (self propertyDictionaryFor: method) isNil.