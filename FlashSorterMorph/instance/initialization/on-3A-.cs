on: aFlashPlayerMorph
	| w h |
	player _ aFlashPlayerMorph.
	w _ player bounds width.
	h _ player bounds height.
	w > h ifTrue:[
		h _ h * 50 // w.
		w _ 50.
	] ifFalse:[
		w _ w * 50 // h.
		h _ 50.
	].
	self addThumbnails: w@h.