processEvents
	"Process user input events from the remote input devices."

	| evt |
	evt _ self getNextRemoteEvent.
	[evt ~~ nil] whileTrue: [
		evt type == #worldExtent ifTrue: [
			remoteWorldExtent _ evt argument.
			^ self].
		self handleEvent: evt.
		evt _ self getNextRemoteEvent]
