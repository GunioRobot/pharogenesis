findClassOfMethod: meth forReceiver: rcvr

	| currClass classDict classDictSize methodArray i done |
	currClass _ self fetchClassOf: rcvr.
	done _ false.
	[done] whileFalse: [
		classDict _ self fetchPointer: MessageDictionaryIndex ofObject: currClass.
		classDictSize _ self fetchWordLengthOf: classDict.
		methodArray _ self fetchPointer: MethodArrayIndex ofObject: classDict.
		i _ 0.
		[i < (classDictSize - SelectorStart)] whileTrue: [
			meth = (self fetchPointer: i ofObject: methodArray) ifTrue: [ ^currClass ].
			i _ i + 1.
		].
		currClass _ self fetchPointer: SuperclassIndex ofObject: currClass.
		done _ currClass = nilObj.
	].
	^self fetchClassOf: rcvr    "method not found in superclass chain"