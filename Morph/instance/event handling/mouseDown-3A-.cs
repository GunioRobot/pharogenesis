mouseDown: evt
	"Handle a mouse down event. The default response is to let my eventHandler, if any, handle it."

	eventHandler ifNotNil:
		[eventHandler mouseDown: evt fromMorph: self].
