mouseUp: evt
	"Handle a mouse up event. The default response is to let my eventHandler, if any, handle it."

	eventHandler ifNotNil:
		[eventHandler mouseUp: evt fromMorph: self].
