implementsVocabulary: aVocabulary
	"Answer whether instances of the receiver respond to the messages in aVocabulary."

	(aVocabulary isKindOf: FullVocabulary orOf: ScreenedVocabulary) ifTrue: [^ true].
	^ self fullyImplementsVocabulary: aVocabulary