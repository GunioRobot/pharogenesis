doOneCycleInBackground
	"Do one cycle of the interactive loop. This method is called repeatedly when this world is not the active window but is running in the background."

	"process user input events, but only for remote hands"
	hands do: [:h | (h isKindOf: RemoteHandMorph) ifTrue: [h processEvents]].
	self runStepMethods.
	self displayWorld.
