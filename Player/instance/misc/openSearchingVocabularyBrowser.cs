openSearchingVocabularyBrowser
	"Open a vocabulary browser on the receiver, showing its etoy vocabulary.  No senders; a disused but presumably still viable path, provisionally retained"

	(Lexicon new useVocabulary: Vocabulary fullVocabulary) openWithSearchPaneOn: self class inWorld: self currentWorld