signalWaitingProcess
	"The delay time has elapsed; signal the waiting process."

	beingWaitedOn _ false.
	delaySemaphore signal.