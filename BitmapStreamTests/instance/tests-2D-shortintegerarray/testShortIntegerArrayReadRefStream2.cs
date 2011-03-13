testShortIntegerArrayReadRefStream2
	|refStrm|
	refStrm := ReferenceStream on: ((RWBinaryOrTextStream with: (ByteArray withAll: #(20 6 17 83 104 111 114 116 73 110 116 101 103 101 114 65 114 114 97 121 0 0 0 2 0 0 0 1 0 2 0 3))) reset; binary).
	self assert: (refStrm next = (ShortIntegerArray with: 0 with: 1 with: 2 with: 3)).