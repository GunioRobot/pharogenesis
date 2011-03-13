morph
	^ self isEmpty 
		ifTrue: [self simplePane]
		ifFalse: [self filter wantsButton
							ifTrue: [self paneWithHeader]
							ifFalse: [self simplePane]]