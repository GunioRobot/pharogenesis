test: byteCount fileName: fileName
	"AsyncFile new test: 10000 fileName: 'testData'"

	| buf1 buf2 bytesWritten bytesRead |
	buf1 _ String new: byteCount withAll: $x.
	buf2 _ String new: byteCount.
	self open: fileName forWrite: true.
	self primWriteStart: fileHandle
		fPosition: 0
		fromBuffer: buf1
		at: 1
		count: byteCount.
	semaphore wait.
	bytesWritten _ self primWriteResult: fileHandle.
	self close.
	
	self open: fileName forWrite: false.
	self primReadStart: fileHandle fPosition: 0 count: byteCount.
	semaphore wait.
	bytesRead _
		self primReadResult: fileHandle
			intoBuffer: buf2
			at: 1
			count: byteCount.
	self close.

	buf1 = buf2 ifFalse: [self error: 'buffers do not match'].
	^ 'wrote ', bytesWritten printString, ' bytes; ',
	   'read ', bytesRead printString, ' bytes'
