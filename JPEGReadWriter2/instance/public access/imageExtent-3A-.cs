imageExtent: aByteArray 
	"Answer the extent of the compressed image encoded in the given ByteArray."

	| jpegDecompressStruct jpegErrorMgr2Struct w h |
	jpegDecompressStruct _ ByteArray new: self primJPEGDecompressStructSize.
	jpegErrorMgr2Struct _ ByteArray new: self primJPEGErrorMgr2StructSize.
	self
		primJPEGReadHeader: jpegDecompressStruct 
		fromByteArray: aByteArray
		errorMgr: jpegErrorMgr2Struct.
	w _ self primImageWidth: jpegDecompressStruct.
	h _ self primImageHeight: jpegDecompressStruct.
	^ w @ h
