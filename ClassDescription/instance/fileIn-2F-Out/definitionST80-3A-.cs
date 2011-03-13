definitionST80: isST80
	"Answer a String that defines the receiver."

	| aStream path |
	isST80 ifTrue: [^ self definitionST80].

	aStream _ WriteStream on: (String new: 300).
	superclass == nil
		ifTrue: [aStream nextPutAll: 'nil']
		ifFalse: [path _ ''.
				self environment scopeFor: superclass name from: nil
						envtAndPathIfFound: [:envt :remotePath | path _ remotePath].
				aStream nextPutAll: path , superclass name].
	aStream nextPutKeyword: self kindOfSubclass
			withArg: self name.
	aStream cr; tab; nextPutKeyword: 'instanceVariableNames: '
			withArg: self instanceVariablesString.
	aStream cr; tab; nextPutKeyword: 'classVariableNames: 'withArg: self classVariablesString.
	aStream cr; tab; nextPutKeyword: 'poolDictionaries: '
			withArg: self sharedPoolsString.
	aStream cr; tab; nextPutKeyword: 'category: '
			withArg: (SystemOrganization categoryOfElement: self name) asString.
	^ aStream contents