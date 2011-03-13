calculateSha1sum
	"Return the checksum of the currently cached file contents."

	^SecureHashAlgorithm new hashMessage: self contents
	
	
		