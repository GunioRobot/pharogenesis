embraceAddedTypeVocabularies
	"If there are any type-vocabulary subclases not otherwise accounted for, acknowledge them at this time"

	| vocabulary |
	DataType allSubclasses do:
		[:dataType |
			vocabulary _ dataType new.
			vocabulary representsAType
				ifTrue: [(self allStandardVocabularies includesKey: vocabulary vocabularyName)
					ifFalse: 	[self addStandardVocabulary: vocabulary]]]