pushBack: aStringOrByteArray
	inStream _ ReadStream on: (aStringOrByteArray , self inStream contents)