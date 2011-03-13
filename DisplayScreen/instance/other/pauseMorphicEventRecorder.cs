pauseMorphicEventRecorder

	self flag: #bob.	
	Smalltalk isMorphic ifTrue: [^World pauseEventRecorder].
	^nil

