doOneCycle
	"Do one cycle of the interactive loop. This method is called repeatedly when the world is running."

	hands do: [:h | h processEvents].  "process user input events"
	self runStepMethods.
	self displayWorld.
