openNotifierContents: msgString label: label
	"Create and schedule a notifier view with the given label and message. A notifier view shows just the message or the first several lines of the stack, with a menu that allows the user to open a full debugger if so desired. Do not terminate the current active process."
	| msg topView p newActiveProcess |
	Sensor flushKeyboard.
	(label beginsWith: 'Space is low')
		ifTrue: [msg _ self lowSpaceChoices, msgString]
		ifFalse: [msg _ msgString].

	World ifNotNil:
		[self buildMorphicNotifierLabelled: label message: msg.
		newActiveProcess _
			[[true] whileTrue: [World doOneCycle.  Processor yield]] newProcess
					priority: Processor userSchedulingPriority.
		^ newActiveProcess resume].

	Display fullScreen.
	Cursor normal show.
	topView _ self buildMVCNotifierViewLabel: label message: msg minSize: 350@((14 * 5) + 16).
	ScheduledControllers activeController
		ifNil: [p _ Display boundingBox center]
		ifNotNil: [p _ ScheduledControllers activeController view displayBox center].
	topView controller openNoTerminateDisplayAt: (p max: (200@60)).
	^ topView
