retrieveContentsEncoding: stringEncoding
	^self openStream: #read forceNew: false encoding: stringEncoding