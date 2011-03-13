storeOn: aStream

	aStream
		nextPutAll: '(Color r:';
		nextPutAll: (self red roundTo: 0.001) printString;
		nextPutAll: ' g: ';
		nextPutAll: (self green roundTo: 0.001) printString;
		nextPutAll: ' b: ';
		nextPutAll: (self blue roundTo: 0.001) printString;
		nextPutAll: ')'.
