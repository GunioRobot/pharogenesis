testShortIntegerArrayWithSmartRefStream2
	array := ShortIntegerArray with: 0 with: 1 with: 2 with: 3.
	self validateSmartRefStream.
	self assert: (stream contents asByteArray last: 15) = (ByteArray withAll: #(0 0 0 2  0 0  0 1  0 2  0 3  33 13 13))
	
