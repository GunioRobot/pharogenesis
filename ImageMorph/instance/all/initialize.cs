initialize
	| d h p |
	super initialize.
	self image: (Form extent: 80@40 depth: Display depth).
	h _ image height // 2.
	0 to: h-1 do: 
		[:i | p _ (i*2)@i.  d _ i asFloat / h asFloat.
		image fill: (p corner: image extent - p) fillColor: (Color r: d g: 0.5 b: 1.0-d)]