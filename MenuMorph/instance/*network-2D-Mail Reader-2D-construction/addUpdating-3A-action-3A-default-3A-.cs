addUpdating: aWordingSelector action: aSymbol  default: ignored
	"for compatibility with MVC"
	self addUpdating: aWordingSelector target: defaultTarget selector: aSymbol argumentList: EmptyArray
