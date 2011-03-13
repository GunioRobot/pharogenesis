definition
	"Answer a String that defines the receiver."

	| aStream |
	aStream _ WriteStream on: (String new: 300).
	aStream nextPutAll: 
		(superclass == nil
			ifTrue: ['nil']
			ifFalse: [superclass name])
		, self kindOfSubclass.
	self name storeOn: aStream.
	aStream cr; tab; nextPutAll: 'instanceVariableNames: '.
	aStream store: self instanceVariablesString.
	aStream cr; tab; nextPutAll: 'classVariableNames: '.
	aStream store: self classVariablesString.
	aStream cr; tab; nextPutAll: 'poolDictionaries: '.
	aStream store: self sharedPoolsString.
	aStream cr; tab; nextPutAll: 'category: '.
	(SystemOrganization categoryOfElement: self name) asString storeOn: aStream.
	^aStream contents