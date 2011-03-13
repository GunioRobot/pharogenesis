urlToDownload

	^ (self url, (self package ifNil: [ '' ])) asUrl asString.
	
 