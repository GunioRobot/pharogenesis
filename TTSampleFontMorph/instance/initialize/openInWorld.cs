openInWorld
	Smalltalk isMorphic ifFalse: [^ self openInMVC].
	HandMorph attach: self