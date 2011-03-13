fileByteCountPerFrame
	
	^ (frameBufferIfScaled ifNil: [currentPage image]) bits size * 4
