resume
	"This method resumes a paused animation"

	(state = Paused) ifTrue:
		[
			state _ Running.
			startTime _ (myScheduler getTime) - pausedInterval.
			endTime _ startTime + duration.
		]
	ifFalse: [(state = Stopped) ifTrue:
				[
					state _ Waiting.
					myScheduler addUpdateItem: self.
				].
			]


