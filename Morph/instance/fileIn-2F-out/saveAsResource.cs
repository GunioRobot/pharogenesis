saveAsResource

	| pathName |
	(self hasProperty: #resourceFilePath) ifFalse: [^ self].
	pathName _ self valueOfProperty: #resourceFilePath.
	(pathName asLowercase endsWith: '.morph') ifFalse:
		[^ self error: 'Can only update morphic resources'].
	(FileStream newFileNamed: pathName) fileOutClass: nil andObject: self.