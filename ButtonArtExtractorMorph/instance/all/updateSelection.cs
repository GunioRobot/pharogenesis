updateSelection
	"Update the selection rectangle and preview after the selection has changed."

	| w newR |
	"contrain selectionRect to be within the visibleLayer bounds"
	w _ selectionRect borderWidth.
	newR _ selectionRect bounds intersect: (visibleLayer bounds expandBy: w).
	selectionRect position: newR origin.
	selectionRect extent: newR extent.
	self updatePreview.
