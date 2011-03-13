testShortPointArrayWithRefStream2
	array := ShortPointArray with: 0@1 with: 2@3.
	self validateRefStream.
	self assert: stream byteStream contents = (ByteArray withAll: #(20 6 15 83 104 111 114 116 80 111 105 110 116 65 114 114 97 121  0 0 0 2  0 0  0 1  0 2  0 3 ))
	