browseEToyVocabulary
	"Open a protocol browser on the receiver, showing its etoy vocabulary"

	| littleMe | 
	littleMe _ self assureUniClass.

	(InstanceBrowser new useVocabulary: Vocabulary eToyVocabulary) openOnObject: littleMe  inWorld: ActiveWorld showingSelector: nil