showSonogram
	"Display a sonogram showing the frequency spectrum versus time."

	| zeros h w |
	displayType _ 'sonogram'.
	self removeAllDisplays.
	h _ fft n // 2.
	h _ h min: 512 max: 64.
	w _ 400.
	sonogramMorph _
		Sonogram new
			extent: w@h
			minVal: 0.0
			maxVal: 1.0
			scrollDelta: w.
	zeros _ Array new: sonogramMorph height withAll: 0.
	sonogramMorph width timesRepeat: [sonogramMorph plotColumn: zeros].
	self addMorphBack: sonogramMorph.
	self extent: 10@10.  "shrink to minimum size"
