initialize
	"ImageMorph initialize"

	| h p d |
	DefaultForm _ (Form extent: 80@40 depth: 16).
	h _ DefaultForm height // 2.
	0 to: h - 1 do: [:i |
		p _ (i * 2)@i.
		d _ i asFloat / h asFloat.
		DefaultForm fill:
			(p corner: DefaultForm extent - p)
			fillColor: (Color r: d g: 0.5 b: 1.0 - d)].

	self registerInFlapsRegistry.