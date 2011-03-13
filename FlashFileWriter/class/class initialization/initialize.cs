initialize
	"FlashFileWriter initialize"
	TagTable := Dictionary new.
	FlashFileReader tagTable doWithIndex:[:tag :index|
		TagTable at: (tag copyWithout: $:) asSymbol put: index
	].