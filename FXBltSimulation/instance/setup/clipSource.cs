clipSource
	"clip and adjust source origin and extent appropriately"
	sx < 0
		ifTrue: [dx _ dx - sx.
				bbW _ bbW + sx.
				sx _ 0].
	sx + bbW > sourceWidth
		ifTrue: [bbW _ bbW - (sx + bbW - sourceWidth)].
	sy < 0
		ifTrue: [dy _ dy - sy.
				bbH _ bbH + sy.
				sy _ 0].
	sy + bbH > sourceHeight
		ifTrue: [bbH _ bbH - (sy + bbH - sourceHeight)]