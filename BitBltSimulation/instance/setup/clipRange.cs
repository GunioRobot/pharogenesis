clipRange
	"clip and adjust source origin and extent appropriately"
	"first in x"
	destX >= clipX
		ifTrue: [sx _ sourceX.
				dx _ destX.
				bbW _ width]
		ifFalse: [sx _ sourceX + (clipX - destX).
				bbW _ width - (clipX - destX).
				dx _ clipX].
	(dx + bbW) > (clipX + clipWidth)
		ifTrue: [bbW _ bbW - ((dx + bbW) - (clipX + clipWidth))].
	"then in y"
	destY >= clipY
		ifTrue: [sy _ sourceY.
				dy _ destY.
				bbH _ height]
		ifFalse: [sy _ sourceY + clipY - destY.
				bbH _ height - (clipY - destY).
				dy _ clipY].
	(dy + bbH) > (clipY + clipHeight)
		ifTrue: [bbH _ bbH - ((dy + bbH) - (clipY + clipHeight))].
	noSource ifTrue: [^ nil].
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