compressFlashImages
	^ self
		valueOfFlag: #compressFlashImages
		ifAbsent: [false]