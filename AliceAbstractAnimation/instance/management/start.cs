start
	"This method starts an existing animation"

	state _ Waiting.
	loopCount _ 1.
	myScheduler addUpdateItem: self.
