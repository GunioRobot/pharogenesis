createStubMethod
	| argNames aOrAn argName arg argClassName |
	argNames _ Set new.
	^ String streamContents: [ :s |
		self selector keywords doWithIndex: [ :key :i |
			s nextPutAll: key.
			((key last = $:) or: [self selector isInfix]) ifTrue: [
				arg _ self arguments at: i.
				argClassName _ (arg isKindOf: Class) ifTrue: ['Class'] ifFalse: [arg class name].
				aOrAn _ argClassName first isVowel ifTrue: ['an'] ifFalse: ['a'].
				argName _ aOrAn, argClassName.
				[argNames includes: argName] whileTrue: [argName _ argName, i asString].
				argNames add: argName.
				s nextPutAll: ' '; nextPutAll: argName; space
			].
		].
		s cr; tab.
		s nextPutAll: 'self shouldBeImplemented'
	]