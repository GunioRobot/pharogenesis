interval: d
	"Supply an optional floating fraction so slider can expand to indicate range"
	interval _ d min: 1.0.
	self expandSlider.
	self computeSlider.