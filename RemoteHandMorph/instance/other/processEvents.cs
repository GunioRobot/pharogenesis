processEvents
	"Process user input events from the remote input devices."

	| evt |
	evt _ self getNextRemoteEvent.
	[evt ~~ nil] whileTrue: [
		evt type == #worldExtent ifTrue: [
			remoteWorldExtent _ evt cursorPoint.
			^ self].

		(evt yellowButtonPressed and:
		 [lastEvent yellowButtonPressed not]) ifTrue: [
			lastEvent _ evt.
			^ self invokeMetaMenu: evt].

		(evt blueButtonPressed and:
		 [lastEvent blueButtonPressed not]) ifTrue: [
			lastEvent _ evt.
			^ self specialGesture: evt].

		self handleEvent: evt.
		lastEvent _ evt.
		evt _ self getNextRemoteEvent].
