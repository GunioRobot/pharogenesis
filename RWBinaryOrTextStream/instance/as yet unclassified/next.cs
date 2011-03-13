next

	| byte |
	^ isBinary 
			ifTrue: [byte _ super next.
				 byte ifNil: [nil] ifNotNil: [byte asciiValue]]
			ifFalse: [super next].
