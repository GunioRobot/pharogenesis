mouseMove: evt
	"Handle a mouse move event. The default response is to let my eventHandler, if any, handle it."

	eventHandler ifNotNil:
		[eventHandler mouseStillDown: evt fromMorph: self].
