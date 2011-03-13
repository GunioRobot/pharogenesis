tinyText: aText scale: m
	"(Form tinyText: 'Hi There!  These caps are 5 high, and
the lower-case are 3 high.  Not bad, eh?' asText allBold scale: 2) display"
	| f1 tiny grays |
	f1 _ aText asDisplayText form.
	tiny _ Form extent: f1 extent//m depth: 8.
	grays _ (0 to: m*m) collect: [:i | 39 - (i*(39-16)//(m*m))].
	0 to: tiny width-1 do:
		[:x | 0 to: tiny height-1 do:
			[:y | tiny pixelValueAt: x@y
				put: (grays at: (f1 sumBitsAt: (x*m)@(y*m) cellSize: m) + 1)]].
	^ tiny