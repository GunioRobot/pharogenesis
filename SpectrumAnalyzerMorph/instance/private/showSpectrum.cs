showSpectrum
	"Display the frequency spectrum."

	displayType _ 'spectrum'.
	self removeAllDisplays.
	graphMorph _ GraphMorph new.
	graphMorph extent: ((fft n // 2) + (2 * graphMorph borderWidth))@128.
	graphMorph data: (Array new: fft n // 2 withAll: 0).
	self addMorphBack: graphMorph.
	self extent: 10@10.  "shrink to minimum size"
