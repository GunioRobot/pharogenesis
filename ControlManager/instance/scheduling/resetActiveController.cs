resetActiveController
	"When saving a morphic project whose parent is mvc, we need to set this up first"

	activeController _ nil.
	activeControllerProcess _ Processor activeProcess.
