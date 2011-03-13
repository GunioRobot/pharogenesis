createStubMethod
	| argNames aOrAn argName arg argClassName |
	argNames := Set new.
	^ String streamContents: [ :s |
		self selector keywords doWithIndex: [ :key :i |
			s nextPutAll: key.
			((key last = $:) or: [self selector isInfix]) ifTrue: [
				arg := self arguments at: i.
				argClassName := (arg isKindOf: Class) ifTrue: ['Class'] ifFalse: [arg class name].
				aOrAn := argClassName first isVowel ifTrue: ['an'] ifFalse: ['a'].
				argName := aOrAn, argClassName.
				[argNames includes: argName] whileTrue: [argName := argName, i asString].
				argNames add: argName.
				s nextPutAll: ' '; nextPutAll: argName; space
			].
		].
		s cr; tab.
		s nextPutAll: 'self shouldBeImplemented'
	]