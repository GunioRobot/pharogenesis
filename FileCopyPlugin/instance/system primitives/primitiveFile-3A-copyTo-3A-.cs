primitiveFile: srcName copyTo: dstName

	|srcSz dstSz ok |
	self primitive: 'primitiveFileCopyNamedTo'
		parameters: #(String String).

	srcSz _ interpreterProxy slotSizeOf: srcName cPtrAsOop.
	dstSz _ interpreterProxy slotSizeOf: dstName cPtrAsOop.
	ok _ self sqCopyFile: srcName size: srcSz to: dstName size: dstSz.
	ok ifFalse:[interpreterProxy primitiveFail].
