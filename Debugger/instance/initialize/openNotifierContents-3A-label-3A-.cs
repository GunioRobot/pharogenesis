openNotifierContents: msgString label: label
	"Create and schedule a notifier view with the given label and message. A notifier view shows just the message or the first several lines of the stack, with a menu that allows the user to open a full debugger if so desired."
	"NOTE: When this method returns, a new process has been scheduled to run the windows, and thus this notifier, but the previous active porcess has not been suspended.  The sender will do this."
	| msg topView p |
	Sensor flushKeyboard.
	savedCursor _ Sensor currentCursor.
	Sensor currentCursor: Cursor normal.
	msg _ msgString.
	(label beginsWith: 'Space is low') ifTrue: [msg _ self lowSpaceChoices, msgString].
	isolationHead ifNotNil:
		["We have already revoked the isolation layer -- now jump to the parent project."
		msg _ self isolationRecoveryAdvice, msgString.
		failedProject _ Project current.
		isolationHead parent enterForEmergencyRecovery].

	Smalltalk isMorphic ifTrue: [
		self buildMorphicNotifierLabelled: label message: msg.
		errorWasInUIProcess _ CurrentProjectRefactoring newProcessIfUI: interruptedProcess.
		^self
	].

	Display fullScreen.
	topView _ self buildMVCNotifierViewLabel: label message: msg minSize: 350@((14 * 5) + 16 + self optionalButtonHeight).
	ScheduledControllers activeController
		ifNil: [p _ Display boundingBox center]
		ifNotNil: [p _ ScheduledControllers activeController view displayBox center].
	topView controller openNoTerminateDisplayAt: (p max: (200@60)).
	^ topView