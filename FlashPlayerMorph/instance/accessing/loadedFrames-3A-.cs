loadedFrames: aNumber 
	self isStreaming
		ifTrue: 
			[activationKeys _ self collectActivationKeys: aNumber.
			aNumber = 1
				ifTrue: 
					[activeMorphs addAll: activationKeys first.
					self changed].
			progressValue contents: aNumber asFloat / maxFrames.
			"Give others a chance"
			Smalltalk isMorphic
				ifTrue: [World doOneCycle]
				ifFalse: [Processor yield]].
	loadedFrames _ aNumber