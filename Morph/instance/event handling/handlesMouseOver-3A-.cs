handlesMouseOver: evt
	"Do I respond to mouseDown, mouseStillDown, or mouseUp?  "
	eventHandler ifNotNil: [^ eventHandler handlesMouseOver: evt].
	^ false