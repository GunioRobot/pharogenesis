resizeTo: aRectangle
	"Resize this view to aRectangle"

	"First get scaling right inside borders"
	self window: (self window insetBy: borderWidth)
		viewport: (aRectangle insetBy: borderWidth).

	"Then ensure window maps to aRectangle"
	window := transformation applyInverseTo: aRectangle