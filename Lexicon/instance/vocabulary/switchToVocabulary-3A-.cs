switchToVocabulary: aVocabulary
	"Make aVocabulary be the current one in the receiver"

	self preserveSelectorIfPossibleSurrounding:
		[self useVocabulary: aVocabulary.
		self reformulateCategoryList.
		self adjustWindowTitle]
