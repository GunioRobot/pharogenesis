deleteFileNamed: localFileName ifAbsent: failBlock
	"Delete the file of the given name if it exists, else evaluate failBlock.
	If the first deletion attempt fails do a GC to force finalization of any lost references. ar 3/21/98 17:53"
	(self 
		retryWithGC:[self primDeleteFileNamed: (self fullNameFor: localFileName)]
		until:[:result| result notNil]) == nil
			ifTrue: [^failBlock value].
