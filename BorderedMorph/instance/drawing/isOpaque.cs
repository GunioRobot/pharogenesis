isOpaque
	color isTransparent ifTrue: [^ false].
	borderWidth = 0
		ifTrue: [^ true]
		ifFalse: [^ borderColor isColor not or: [borderColor isTransparent not]]