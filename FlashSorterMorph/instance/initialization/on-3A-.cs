on: aFlashPlayerMorph
	| w h |
	player := aFlashPlayerMorph.
	w := player bounds width.
	h := player bounds height.
	w > h ifTrue:[
		h := h * 50 // w.
		w := 50.
	] ifFalse:[
		w := w * 50 // h.
		h := 50.
	].
	self addThumbnails: w@h.