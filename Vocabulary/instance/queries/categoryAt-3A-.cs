categoryAt: aSymbol
	"Answer the category which has the given symbol as its categoryName, else nil if none found"

	^ categories detect: [:aCategory | aCategory categoryName == aSymbol] ifNone: [nil]