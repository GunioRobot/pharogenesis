showSignal
	"Display the actual signal waveform."

	displayType _ 'signal'.
	self removeAllDisplays.
	graphMorph _ GraphMorph new.
	graphMorph extent: (400 + (2 * graphMorph borderWidth))@128.
	graphMorph data: (Array new: 100 withAll: 0).
	graphMorph color: (Color r: 0.8 g: 1.0 b: 1.0).
	self addMorphBack: graphMorph.
	self extent: 10@10.  "shrink to minimum size"
