updatePaneColors
	"Useful when changing from monochrome to color display"

	self setStripeColorsFrom: self paneColorToUse.
	paneMorphs do: [:p | p color: self paneColorToUse].
