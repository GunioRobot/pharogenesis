correctSha1sum: content
	"Return if the checksum of the content is correct.
	If we have none, then we consider that to be correct."
	
	^sha1sum isNil or: [sha1sum = (SecureHashAlgorithm new hashMessage: content)]
	
	
		