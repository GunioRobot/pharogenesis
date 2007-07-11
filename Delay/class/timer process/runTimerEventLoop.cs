runTimerEventLoop
	"Run the timer event loop."
	[
		[RunTimerEventLoop] whileTrue: [self handleTimerEvent]
	] on: Error do:[:ex|
		"Clear out the process so it does't get killed"
		TimerEventLoop := nil.
		"Launch the old-style interrupt watcher"
		self startTimerInterruptWatcher.
		"And pass the exception on"
		ex pass.
	].