justDroppedInto: aMorph event: anEvent
	"This menu was grabbed and moved. Save us from being deleted by the mouseUp event."
	stayUp ifFalse: [self setProperty: #stayUpOnce toValue: true].
	super justDroppedInto: aMorph event: anEvent