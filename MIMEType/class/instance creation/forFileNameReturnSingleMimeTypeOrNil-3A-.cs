forFileNameReturnSingleMimeTypeOrNil: fileName
	| types |
	types := self forFileNameReturnMimeTypesOrNil: fileName.
	types ifNotNil: [^types first].
	^nil