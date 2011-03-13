updateFromResource

	| pathName newMorph f |
	(pathName _ self valueOfProperty: #resourceFilePath) ifNil: [^ self].
	(pathName asLowercase endsWith: '.morph')
		ifTrue:
			[newMorph _ (FileStream readOnlyFileNamed: pathName) fileInObjectAndCode.
			(newMorph isKindOf: Morph) ifFalse: [^ self error: 'Resource not a single morph']]
		ifFalse:
			[f _ Form fromFileNamed: pathName.
			f ifNil: [^ self error: 'unrecognized image file format'].
			newMorph _ SketchMorph withForm: f].
	newMorph setProperty: #resourceFilePath toValue: pathName.
	self owner replaceSubmorph: self by: newMorph
