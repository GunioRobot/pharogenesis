doItInFile: fileName withModule: withModuleFlag 
	"Stores output in a new file named 'filename'.
	Param 'withModuleFlag' has to be true, if there is a reachable module, false otherwise."
	| stream |
	stream _ FileStream newFileNamed: fileName.
	LargeIntegersTest doItOn: stream withModule: withModuleFlag.
	stream close