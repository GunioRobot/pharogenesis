testShortRunArrayWithSmartRefStream2
	array := self createSampleShortRunArray.
	self validateSmartRefStream.
	self assert: (stream contents asByteArray last: 23) = (ByteArray withAll: #(0 0 0 4 0 1 0 0 0 2 0 1 0 3 0 2 0 4 0 3 33 13 13))

