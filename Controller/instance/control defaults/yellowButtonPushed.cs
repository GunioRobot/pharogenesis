yellowButtonPushed
	| message superView menu |
	"Supports several controllers whose only common ancestor is Controller"
	menu _  Sensor leftShiftDown
		ifTrue: [self class debuggingMenu]
		ifFalse: [self class editingMenu].
	message _ menu startUpWithCaption: model class name.
	((superView _ view superView) respondsTo: message)
		ifTrue: [superView perform: message]
		ifFalse: [(view respondsTo: message)
			ifTrue: [view perform: message]
			ifFalse: [self perform: message]]