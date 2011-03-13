adjustSubmorphPositions

	| p h |

	p _ 0@0.
	scroller submorphsDo: [ :each |
		h _ each height.
		each privateBounds: (p extent: 9999@h).
		p _ p + (0@h)
	].
	self 
		changed;
		layoutChanged;
		setScrollDeltas.
