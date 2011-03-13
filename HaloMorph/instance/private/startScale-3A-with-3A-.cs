startScale: evt with: scaleHandle
	"Initialize scaling of my target."

	self obtainHaloForEvent: evt andRemoveAllHandlesBut: scaleHandle.
	target isFlexMorph ifFalse: [target addFlexShellIfNecessary].
	growingOrRotating _ true.
	positionOffset _ 0@0.

	self setProperty: #commandInProgress toValue:
		(Command new
			cmdWording: ('resize ' translated, target nameForUndoWording);
			undoTarget: target renderedMorph selector: #setFlexExtentFromHalo: argument: target extent).
	originalExtent _ target extent
