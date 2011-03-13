initialize
	"NaturalLanguageTranslator initialize"

	FileList registerFileReader: self.
	Smalltalk addToStartUpList: NaturalLanguageTranslator after: PasteUpMorph
		"since may use progress bar"
