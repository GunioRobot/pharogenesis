isPartsDonor: aBoolean
	extension == nil ifTrue:
		[aBoolean ifFalse: [^ self].
		self assureExtension].
	extension isPartsDonor: aBoolean