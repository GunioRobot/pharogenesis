testIncludesKey
	self deny: (method properties includesKey: #zork).
	self assert: (self propertyDictionaryFor: method) isNil.
	method properties at: #zork put: 123.
	self assert: (method properties includesKey: #zork).