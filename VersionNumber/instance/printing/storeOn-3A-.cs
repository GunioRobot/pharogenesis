storeOn: strm

	strm nextPut: $'.
	self versionStringOn: strm.
	strm nextPutAll: ''' asVersion'.