definition
	"Answer a String that defines the receiver."

	| aStream path |
	aStream _ WriteStream on: (String new: 300).
	superclass == nil
		ifTrue: [aStream nextPutAll: 'nil']
		ifFalse: [path _ ''.
				self environment scopeFor: superclass name from: nil
						envtAndPathIfFound: [:envt :remotePath | path _ remotePath].
				aStream nextPutAll: path , superclass name].
	aStream nextPutAll: self kindOfSubclass.
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