assertIsTranslatedMethod: anObject
	(self fetchClassOf: anObject) = (self splObj: ClassTranslatedMethod)
		ifFalse: [self error: 'translated method expected'].