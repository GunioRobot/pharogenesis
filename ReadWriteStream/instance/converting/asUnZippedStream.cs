asUnZippedStream
	| isGZip outputStream first |
	"Decompress this file if needed, and return a stream.  No file is written.  File extension may be .gz or anything else."

	self binary.
	first _ self next.
	isGZip _ (self next * 256 + first) = (GZipConstants at: #GZipMagic).
	self skip: -2.
	isGZip 
		ifTrue: [outputStream _ (RWBinaryOrTextStream with:
					(GZipReadStream on: self) upToEnd) reset.
				self close]
		ifFalse: [outputStream _ self].
	^ outputStream