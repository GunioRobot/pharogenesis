vrmlProtoCopy
	^self shallowCopy protoValues: (self protoValues collect:[:each| each vrmlProtoCopy])