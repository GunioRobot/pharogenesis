mouseMove: evt

	| w p |
	selectMode = #move ifTrue: [
		w _ selectionRect borderWidth.
		p _ evt cursorPoint - selectOffset.
		p _ p adhereTo:
			((visibleLayer topLeft - w) extent:
			 (visibleLayer extent - selectionRect innerBounds extent)).
		selectionRect position: p.
		self updatePreview].

	selectMode = #grow ifTrue: [
		selectionRect extent: (evt cursorPoint - selectionRect topLeft).
		self updateSelection].
