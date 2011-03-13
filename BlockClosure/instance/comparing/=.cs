= other

	self class == other class ifFalse: [^ false].
	self env = other env ifFalse: [^ false].
	self method == other method ifTrue: [^true].
	^ self method = other method