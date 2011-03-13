openNotifierContents: msgString label: label
	"Create and schedule a notifier view with the given label and message. A notifier view shows just the message or the first several lines of the stack, with a menu that allows the user to open a full debugger if so desired."
	"NOTE: When this method returns, a new process has been scheduled to run the windows, and thus this notifier, but the previous active porcess has not been suspended.  The sender will do this."
	| msg topView p |
	Sensor flushKeyboard.
	savedCursor := Sensor currentCursor.
	Sensor currentCursor: Cursor normal.
	(label beginsWith: 'Space is low')
		ifTrue: [msg := self lowSpaceChoices, (msgString ifNil: [''])]
		ifFalse: [msg := msgString].
	isolationHead ifNotNil:
		["We have already revoked the isolation layer -- now jump to the parent project."
		msg := self isolationRecoveryAdvice, msgString.
		failedProject := Project current.
		isolationHead parent enterForEmergencyRecovery].

	Smalltalk isMorphic ifTrue: [
		self buildMorphicNotifierLabelled: label message: msg.
		errorWasInUIProcess := Project spawnNewProcessIfThisIsUI: interruptedProcess.
		^self
	].

	Display fullScreen.
	topView := self 
		buildMVCNotifierViewLabel: label 
		message: thisContext sender sender shortStack 
		minSize: 350@((14 * 5) + 16 + self optionalButtonHeight).
	ScheduledControllers activeController
		ifNil: [p := Display boundingBox center]
		ifNotNil: [p := ScheduledControllers activeController view displayBox center].
	topView controller openNoTerminateDisplayAt: (p max: (200@60)).
	^ topView