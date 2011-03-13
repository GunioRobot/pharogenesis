copyWithTempNames: tempNames
	| tempStr compressed |
	tempStr := String streamContents:
		[:strm | tempNames do: [:n | strm nextPutAll: n; space]].
	compressed := self qCompress: tempStr firstTry: true.
	compressed ifNil:
		["failure case (tempStr too big) will just decompile with tNN names"
		^ self copyWithTrailerBytes: #(0 0 0 0)].
	^ self copyWithTrailerBytes: compressed