fullVocabulary
	"Answer the full vocabulary in my AllVocabularies list, creating it if necessary"

	| it |
	^ self allVocabularies detect: [:aVocabulary | aVocabulary isMemberOf: FullVocabulary]
		ifNone: [AllVocabularies add: (it _ FullVocabulary new).  it]