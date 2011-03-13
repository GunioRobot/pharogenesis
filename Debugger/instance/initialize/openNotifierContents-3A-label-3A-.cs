openNotifierContents: msgString label: label 
	"Create and schedule a notifier view with the given label and message.
	A notifier view shows just the message or the first several lines of the
	stack, with a menu that allows the user to open a full debugger if so
	desired. "
	"NOTE: When this method returns, a new process has been scheduled to
	run the windows, and thus this notifier, but the previous active porcess
	has not been suspended. The sender will do this."
	| msg |
	Sensor flushKeyboard.
	savedCursor := Sensor currentCursor.
	Sensor currentCursor: Cursor normal.
	(label beginsWith: 'Space is low')
		ifTrue: [msg := self lowSpaceChoices
						, (msgString
								ifNil: [''])]
		ifFalse: [msg := msgString].
	isolationHead
		ifNotNil: ["We have already revoked the isolation layer -- now jump to the
			parent project."
			msg := self isolationRecoveryAdvice , msgString.
			failedProject := Project current.
			isolationHead parent enterForEmergencyRecovery].
	self buildNotifierLabelled: label message: msg.
	errorWasInUIProcess := Project spawnNewProcessIfThisIsUI: interruptedProcess