haveFullProtocolBrowsedShowingSelector: aSelector
	"Open up a Lexicon on the receiver, having it open up showing aSelector, which may be nil"

	| aBrowser |
	aBrowser _ InstanceBrowser new useVocabulary: Vocabulary fullVocabulary.
	aBrowser openOnObject: self inWorld: ActiveWorld showingSelector: aSelector

	"(2@3) haveFullProtocolBrowsed"