classAndSelectorOfMethod: meth forReceiver: rcvr
	| mClass dict length methodArray |
	mClass _ self fetchClassOf: rcvr.
	[dict _ self fetchPointer: MessageDictionaryIndex ofObject: mClass.
	length _ self fetchWordLengthOf: dict.
	methodArray _ self fetchPointer: MethodArrayIndex ofObject: dict.
	0 to: length-SelectorStart-1 do: 
		[:index | 
		meth = (self fetchPointer: index ofObject: methodArray) 
			ifTrue: [^ Array
				with: mClass
				with: (self fetchPointer: index + SelectorStart ofObject: dict)]].
	mClass _ self fetchPointer: SuperclassIndex ofObject: mClass.
	mClass = nilObj]
		whileFalse: [].
	^ Array
		with: (self fetchClassOf: rcvr)
		with: (self splObj: SelectorDoesNotUnderstand)