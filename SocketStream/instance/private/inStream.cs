inStream
	inStream ifNil: [inStream _ ReadStream on: (self streamBuffer: 0)].
	^inStream