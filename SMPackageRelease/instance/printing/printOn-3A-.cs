printOn: aStream

	aStream nextPutAll: self class name, '[', self packageNameWithVersion, ']'