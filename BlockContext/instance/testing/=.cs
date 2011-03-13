= other

	self class == other class ifFalse: [^ false].
	self home receiver == other home receiver ifFalse: [^ false].
	self home selector == other home selector ifFalse: [^ false].
	^ self startpc == other startpc
