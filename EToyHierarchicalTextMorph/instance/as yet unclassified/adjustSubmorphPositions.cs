adjustSubmorphPositions

	| p h w |

	p _ 0@0.
	w _ self width.
	scroller submorphsDo: [ :each |
		h _ each position: p andWidth: w.
		p _ p + (0@h)
	].
	self 
		changed;
		layoutChanged;
		setScrollDeltas.
