testToolRegisteredUsingInterface
	"(self selector: #testToolRegisteredUsingInterface) debug"

	self assert: (FileList isReaderNamedRegistered: #DummyToolWorkingWithFileList)