schemeIsFile
	self scheme ifNil: [^false].
	^self scheme asLowercase = 'file'