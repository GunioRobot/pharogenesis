currentVocabularyFor: aScriptableObject 
	"Answer the Vocabulary object to be applied when scripting an object in the world."

	| vocabSymbol vocab aPointVocab |
	vocabSymbol := self valueOfProperty: #currentVocabularySymbol
				ifAbsent: [nil].
	vocabSymbol ifNil: 
			[vocab := self valueOfProperty: #currentVocabulary ifAbsent: [nil].
			vocab ifNotNil: 
					[vocabSymbol := vocab vocabularyName.
					self removeProperty: #currentVocabulary.
					self setProperty: #currentVocabularySymbol toValue: vocabSymbol]].
	vocabSymbol ifNotNil: [^Vocabulary vocabularyNamed: vocabSymbol]
		ifNil: 
			[(aScriptableObject isPlayerLike) ifTrue: [^Vocabulary eToyVocabulary].
			(aScriptableObject isNumber) 
				ifTrue: [^Vocabulary numberVocabulary].
			(aScriptableObject isKindOf: Time) 
				ifTrue: [^Vocabulary vocabularyForClass: Time].
			(aScriptableObject isString) 
				ifTrue: [^Vocabulary vocabularyForClass: String].
			(aScriptableObject isPoint) 
				ifTrue: 
					[(aPointVocab := Vocabulary vocabularyForClass: Point) 
						ifNotNil: [^aPointVocab]].
			(aScriptableObject isKindOf: Date) 
				ifTrue: [^Vocabulary vocabularyForClass: Date].
			"OrderedCollection and Holder??"
			^Vocabulary fullVocabulary]