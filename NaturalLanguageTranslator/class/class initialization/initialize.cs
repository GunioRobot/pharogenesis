initialize
	"NaturalLanguageTranslator initialize"

	FileList registerFileReader: self.
	Smalltalk addToStartUpList: NaturalLanguageTranslator after: FileDirectory.
