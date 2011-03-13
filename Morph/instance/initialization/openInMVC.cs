openInMVC
	Smalltalk isMorphic ifTrue: [^ self openInWorld].
	MorphWorldView openWorldWith: self labelled: self defaultLabelForInspector