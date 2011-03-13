initializeStandardVocabularies
	"Initialize a few standard vocabularies and place them in the AllVocabularies list."

	AllVocabularies _ OrderedCollection new.
	self addVocabulary: EToyVocabulary new.
	self addVocabulary: self newTestVocabulary.
	self addVocabulary: self newPublicVocabulary.
	self addVocabulary: FullVocabulary new.
	self addVocabulary: self newNumberVocabulary.

	"Vocabulary initialize"

