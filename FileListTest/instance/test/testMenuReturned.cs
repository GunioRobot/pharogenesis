testMenuReturned
	"(self selector: #testToolRegistered) debug"

	self assert: (FileList registeredFileReaderClasses includes: DummyToolWorkingWithFileList)