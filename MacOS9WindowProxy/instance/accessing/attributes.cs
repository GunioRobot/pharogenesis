attributes
	| val |
	val := ByteArray new: 8.
	val 
		unsignedLongAt: 1
		put: windowClass
		bigEndian: SmalltalkImage current isBigEndian.
	val 
		unsignedLongAt: 5
		put: windowAttributes
		bigEndian: SmalltalkImage current isBigEndian.
	^ val