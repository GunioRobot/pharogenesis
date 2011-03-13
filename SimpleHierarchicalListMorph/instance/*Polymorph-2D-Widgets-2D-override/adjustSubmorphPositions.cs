adjustSubmorphPositions
	"Fixed to not require setting item widths to 9999."
	
	| p h |
	p := 0@0.
	scroller submorphsDo: [ :each |
		h := each height.
		each privateBounds: (p extent: each width@h).
		p := p + (0@h)
	].
	self 
		changed;
		layoutChanged;
		setScrollDeltas.
