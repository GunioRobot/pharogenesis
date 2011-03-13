printOn: aStream

	aStream
		nextPutAll: 'Color(';
		nextPutAll: (self red roundTo: 0.001) printString;
		nextPutAll: ', ';
		nextPutAll: (self green roundTo: 0.001) printString;
		nextPutAll: ', ';
		nextPutAll: (self blue roundTo: 0.001) printString;
		nextPutAll: ')'.
