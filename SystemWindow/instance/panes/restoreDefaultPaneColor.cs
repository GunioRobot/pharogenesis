restoreDefaultPaneColor
	"Useful when changing from monochrome to color display"

	self setStripeColorsFrom: self paneColor.
	paneMorphs do: [:p | p color: self paneColor].
