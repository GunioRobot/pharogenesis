openNotifier: aDebugger contents: msgString label: label
	"Create and schedule a simple view with a debugger which can be opened later."
	| aStringHolderView topView displayPoint nLines |
	self flag: #developmentNote.
	Cursor normal show.
	aStringHolderView _ StringHolderView container:
		(StringHolder new contents: msgString).
	aStringHolderView controller: (NotifyStringHolderController debugger: aDebugger).
	topView _ StandardSystemView new.
	topView model: aStringHolderView model.
	topView addSubView: aStringHolderView.
	topView label: label.
	nLines _ 1 + (msgString occurrencesOf: Character cr).
	topView minimumSize: 350 @ (14*nLines + 6).
	displayPoint _ 
		ScheduledControllers activeController == nil
			ifTrue: [Display boundingBox center]
			ifFalse: [ScheduledControllers activeController view displayBox center].
	topView controller openNoTerminateDisplayAt: displayPoint.
	^ topView