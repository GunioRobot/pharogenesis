printOn: aStream
	"print this as a hex address ('@ 16rFFFFFFFF') to distinguish it from ByteArrays"

	aStream nextPutAll: '@ '; nextPutAll: self asInteger hex8