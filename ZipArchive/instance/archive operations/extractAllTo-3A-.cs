extractAllTo: aDirectory
	"Extract all elements to the given directory"
	Utilities informUserDuring:[:bar|self extractAllTo: aDirectory informing: bar].