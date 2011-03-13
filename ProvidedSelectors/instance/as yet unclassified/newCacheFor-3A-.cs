newCacheFor: aClass 

	| cache |
	aClass ifNil: [^IdentitySet new].
	cache := self for: aClass superclass copy.
	aClass selectorsAndMethodsDo: [:s :m | 
		m isProvided 
			ifTrue: [cache add: s]
			ifFalse: [cache remove: s ifAbsent: []]].
	^cache