openLexicon
	"Open a lexicon browser on the receiver, showing its current vocabulary"

	| littleHim | 
	littleHim _ scriptedPlayer assureUniClass.

	(InstanceBrowser new useVocabulary: self currentVocabulary) openOnObject: littleHim  inWorld: ActiveWorld showingSelector: nil