adjustSubmorphPositions

	| p h w |

	p := 0@0.
	w := self width.
	scroller submorphsDo: [ :each |
		h := each position: p andWidth: w.
		p := p + (0@h)
	].
	self 
		changed;
		layoutChanged;
		setScrollDeltas.
