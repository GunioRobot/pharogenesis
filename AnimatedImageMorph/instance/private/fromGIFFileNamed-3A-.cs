fromGIFFileNamed: fileName
	self fromReader: (AnimatedGIFReadWriter formsFromFileNamed: fileName)