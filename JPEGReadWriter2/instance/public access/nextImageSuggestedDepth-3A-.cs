nextImageSuggestedDepth: depth
	"Decode and answer a Form of the given depth from my stream. Close the stream if it is a file stream. Possible depths are 16-bit and 32-bit."

	| bytes width height form jpegDecompressStruct jpegErrorMgr2Struct depthToUse |
	bytes _ stream upToEnd.
	stream close.
	jpegDecompressStruct _ ByteArray new: self primJPEGDecompressStructSize.
	jpegErrorMgr2Struct _ ByteArray new: self primJPEGErrorMgr2StructSize.
	self 
		primJPEGReadHeader: jpegDecompressStruct 
		fromByteArray: bytes
		errorMgr: jpegErrorMgr2Struct.
	width _ self primImageWidth: jpegDecompressStruct.
	height _ self primImageHeight: jpegDecompressStruct.
	"Odd width images of depth 16 gave problems. Avoid them (or check carefully!)"
	depthToUse _ ((depth = 32) | width odd) ifTrue: [32] ifFalse: [16].
	form _ Form extent: width@height depth: depthToUse.
	(width = 0 or: [height = 0]) ifTrue: [^ form].
	self
		primJPEGReadImage: jpegDecompressStruct
		fromByteArray: bytes
		onForm: form
		doDithering: true
		errorMgr: jpegErrorMgr2Struct.
	^ form
