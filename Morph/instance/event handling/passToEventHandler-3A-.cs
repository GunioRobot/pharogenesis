passToEventHandler: evt
	"Pass the given event to my event handler, if any."

	eventHandler ifNotNil:
		[eventHandler handleEvent: evt fromMorph: self].
