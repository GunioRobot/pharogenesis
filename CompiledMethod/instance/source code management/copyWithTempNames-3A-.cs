copyWithTempNames: tempNames
	| tempStr |
	tempStr _ String streamContents:
		[:strm | tempNames do: [:n | strm nextPutAll: n; space]].
	^ self copyWithTrailerBytes: (self qCompress: tempStr)