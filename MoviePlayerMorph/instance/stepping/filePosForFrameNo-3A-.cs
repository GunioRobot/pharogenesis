filePosForFrameNo: frameNo
	
	^ 128 + ((frameNo-1)*(4+self fileByteCountPerFrame)) + 4
