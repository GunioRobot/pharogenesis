makeVectorUseConformToPreference
	"Make certain that the use of vectors in this project conforms to the current preference setting."

	| prefValue currentValue |
	prefValue _ Preferences useVectorVocabulary.
	currentValue _ self currentlyUsingVectorVocabulary.
	prefValue ~~ currentValue ifTrue:
		[currentValue
			ifTrue:
				[self abandonVocabularyPreference]
			ifFalse:
				[self installVectorVocabulary]]