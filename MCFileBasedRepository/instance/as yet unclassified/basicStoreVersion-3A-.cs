basicStoreVersion: aVersion
	self
		writeStreamForFileNamed: aVersion fileName
		do: [:s | aVersion fileOutOn: s].