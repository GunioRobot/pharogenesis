openNotifier: aDebugger contents: msgString label: label
	"Create and schedule a simple view with a debugger which can be opened later."

	| msg aStringHolderView topView nLines displayPoint |
	Cursor normal show.
	Sensor flushKeyboard.
	msg _ msgString.
	(label beginsWith: 'Space is low')
		ifTrue: [msg _ self lowSpaceChoices, msg].
	aStringHolderView _
		StringHolderView container: (StringHolder new contents: msg).
	aStringHolderView controller: (NotifyStringHolderController debugger: aDebugger).
	topView _ StandardSystemView new.
	topView model: aStringHolderView model.
	topView addSubView: aStringHolderView.
	topView label: label.
	nLines _ 1 + (msg occurrencesOf: Character cr).
	topView minimumSize: 350 @ (14 * nLines + 6).
	displayPoint _
		ScheduledControllers activeController == nil
			ifTrue: [Display boundingBox center]
			ifFalse: [ScheduledControllers activeController view displayBox center].
	displayPoint _ displayPoint max: (200@40).
	topView controller openNoTerminateDisplayAt: displayPoint.
	^ topView
