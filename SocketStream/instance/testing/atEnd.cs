atEnd
	^self isConnected not
		and: [self isDataAvailable not]