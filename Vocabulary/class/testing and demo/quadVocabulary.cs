quadVocabulary
	"Answer the Quad vocabulary lurking in my AllStandardVocabularies list, creating it if necessary"
	"Vocabulary quadVocabulary"

	^ self allStandardVocabularies at: #Quad ifAbsentPut: [self newQuadVocabulary]