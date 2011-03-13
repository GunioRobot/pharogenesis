sizeCodeForLoad: encoder
	^remoteNode isNil
		ifTrue: [0]
		ifFalse: [remoteNode sizeCodeForLoadFor: self encoder: encoder]