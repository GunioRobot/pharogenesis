setAsBackground
	"Set this form as a background image."

	Smalltalk isMorphic 
		ifTrue: [self currentWorld color: (InfiniteForm with: self)]
		ifFalse:
			[ScheduledControllers screenController model form: self.
			Display restoreAfter: []]