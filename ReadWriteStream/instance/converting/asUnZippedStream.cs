asUnZippedStream
	| isGZip outputStream first strm archive which |
	"Decompress this file if needed, and return a stream.  No file is written.  File extension may be .gz or anything else.  Also works on archives (.zip, .gZip)."

	strm _ self binary.
	strm isZipArchive ifTrue: [
		archive _ ZipArchive new readFrom: strm.
		which _ archive members detect: [:any | any fileName asLowercase endsWith: '.ttf'] 
								ifNone: [nil].
		which ifNil: [archive close.
					^ self error: 'Can''t find .ttf file in archive'].
		strm _ which contentStream.
		archive close].

	first _ strm next.
	isGZip _ (strm next * 256 + first) = (GZipConstants gzipMagic).
	strm skip: -2.
	isGZip 
		ifTrue: [outputStream _ (MultiByteBinaryOrTextStream with:
									(GZipReadStream on: strm) upToEnd) reset.
				strm close]
		ifFalse: [outputStream _ strm].
	^ outputStream