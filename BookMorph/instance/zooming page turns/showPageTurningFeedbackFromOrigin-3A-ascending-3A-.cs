showPageTurningFeedbackFromOrigin: oldOrigin ascending: ascending
	ascending ifNotNil:
		[self playPageFlipSound.
		(PageFlipSoundOn and: [oldOrigin ~~ nil]) ifTrue:
			[Display wipeImage: currentPage imageForm
				at: oldOrigin
				delta: (ascending ifTrue: [0@-4] ifFalse: [0@4])]]