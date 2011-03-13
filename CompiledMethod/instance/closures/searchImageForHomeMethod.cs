searchImageForHomeMethod

	Smalltalk allObjectsDo: [:obj |
		obj class == CompiledMethod ifTrue: [
			(obj pointsTo: self) ifTrue: [^ obj searchImageForHomeMethod]
		] ifFalse: [obj class == BlockClosure ifTrue: [
			(obj method == self and: [obj size = 0])
				ifTrue: [^ obj searchImageForHomeMethod]
		]]
	].
	^ self  "must be a loner block method"