findSelectorOfMethod: meth forReceiver: rcvr

	| currClass done classDict classDictSize methodArray i |
	currClass _ self fetchClassOf: rcvr.
	done _ false.
	[done] whileFalse: [
		classDict _ self fetchPointer: MessageDictionaryIndex ofObject: currClass.
		classDictSize _ self fetchWordLengthOf: classDict.
		methodArray _ self fetchPointer: MethodArrayIndex ofObject: classDict.
		i _ 0.
		[i <= (classDictSize - SelectorStart)] whileTrue: [
			meth = (self fetchPointer: i ofObject: methodArray) ifTrue: [
				^(self fetchPointer: i + SelectorStart ofObject: classDict)
			].
			i _ i + 1.
		].
		currClass _ self fetchPointer: SuperclassIndex ofObject: currClass.
		done _ currClass = nilObj.
	].
	^self splObj: SelectorDoesNotUnderstand    "method not found in superclass chain"