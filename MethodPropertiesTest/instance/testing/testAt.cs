testAt
	self should: [ method properties at: #zork ] raise: Error.
	self assert: (self propertyDictionaryFor: method) isNil.
	method properties at: #zork put: 'hello'.
	self assert: (method properties at: #zork) = 'hello'.