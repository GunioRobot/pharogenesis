lock: aBoolean
	extension == nil ifTrue:
		[aBoolean ifFalse: [^ self].
		self assureExtension].
	extension locked: aBoolean