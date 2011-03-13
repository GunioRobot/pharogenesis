newPublicVocabulary
	| aVocabulary |
	"Answer a public vocabulary"

	aVocabulary _ ScreenedVocabulary new.
	aVocabulary vocabularyName: #Public.
	aVocabulary documentation: '"Public" is vocabulary that excludes categories that start with "private" and methods that start with "private" or "pvt"'.

	aVocabulary categoryScreeningBlock: [:aCategoryName | (aCategoryName beginsWith: 'private') not].
	aVocabulary methodScreeningBlock: [:aSelector | 
		((aSelector beginsWith: 'private') or: [aSelector beginsWith: 'pvt']) not].
	^ aVocabulary
