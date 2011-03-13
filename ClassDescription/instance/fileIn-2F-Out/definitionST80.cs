definitionST80
	"Answer a String that defines the receiver."

	| aStream path |
	aStream _ WriteStream on: (String new: 300).
	superclass == nil
		ifTrue: [aStream nextPutAll: 'nil']
		ifFalse: [path _ ''.
				self environment scopeFor: superclass name from: nil
						envtAndPathIfFound: [:envt :remotePath | path _ remotePath].
				aStream nextPutAll: path , superclass name].
	aStream nextPutAll: self kindOfSubclass;
			store: self name.
	aStream cr; tab; nextPutAll: 'instanceVariableNames: ';
			store: self instanceVariablesString.
	aStream cr; tab; nextPutAll: 'classVariableNames: ';
			store: self classVariablesString.
	aStream cr; tab; nextPutAll: 'poolDictionaries: ';
			store: self sharedPoolsString.
	aStream cr; tab; nextPutAll: 'category: ';
			store: (SystemOrganization categoryOfElement: self name) asString.
	^ aStream contents