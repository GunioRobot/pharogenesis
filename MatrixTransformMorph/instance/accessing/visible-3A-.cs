visible: aBool
	extension == nil ifTrue:[
		aBool ifTrue:[^self].
		self assureExtension].
	extension visible: aBool.