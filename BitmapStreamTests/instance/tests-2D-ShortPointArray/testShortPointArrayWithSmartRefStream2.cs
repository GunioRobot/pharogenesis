testShortPointArrayWithSmartRefStream2
	array := ShortPointArray with: 0@1 with: 2@3.
	self validateSmartRefStream.
	self assert: (stream contents asByteArray last: 15) = (ByteArray withAll: #(0 0 0 2  0 0  0 1  0 2  0 3  33 13 13))
	