contents
	"Return the contents of a stream from the downloaded resource.
	Not yet tested, this resource returns the stream and not its contents."

	map cache add: self.
	^(self cacheDirectory readOnlyFileNamed: self downloadFileName) binary; yourself