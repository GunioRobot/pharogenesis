lastError

	|range|
	range _ self lastErrorCodeRange.
	^String streamContents: [:aStream |
		aStream
			nextPutAll: 'Error #';
			nextPutAll: self lastErrorNumber asString;
			nextPutAll: ': ';
			nextPutAll: self lastErrorString;
			nextPutAll: ' (code ';
			nextPutAll: range first asString;
			nextPutAll: ' to ';
			nextPutAll: range last asString;
			nextPutAll: ').']