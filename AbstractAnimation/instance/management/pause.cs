pause
	"This method pauses an active Animation."

	(state = Running) ifTrue: [ state _ Paused. 
							    pausedInterval _ (myScheduler getTime) - startTime.].
