initialize
	"FlashFileWriter initialize"
	TagTable _ Dictionary new.
	FlashFileReader tagTable doWithIndex:[:tag :index|
		TagTable at: (tag copyWithout: $:) asSymbol put: index
	].