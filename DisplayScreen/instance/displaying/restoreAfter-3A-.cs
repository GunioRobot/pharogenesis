restoreAfter: aBlock
	"Evaluate the block, wait for a mouse click, and then restore the screen"
	aBlock value.
	Sensor waitButton.
	ScheduledControllers  restore.
	ScheduledControllers activeController view emphasize