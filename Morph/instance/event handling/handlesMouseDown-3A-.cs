handlesMouseDown: evt
	"Return true if this morph handles mouse events (mouseDown, mouseMove, mouseUp) itself or if its event handler does. Subclasses that implement mouse events typically override this message."

	eventHandler ifNotNil: [^ eventHandler handlesMouseDown: evt].
	^ false
