clipRange
	"clip and adjust source origin and extent appropriately"
	"first in x"
	| sx sy dx dy bbW bbH |
	"fill in the lazy state if needed"
	destX ifNil:[destX := 0].
	destY ifNil:[destY := 0].
	width ifNil:[width := destForm width].
	height ifNil:[height := destForm height].
	sourceX ifNil:[sourceX := 0].
	sourceY ifNil:[sourceY := 0].
	clipX ifNil:[clipX := 0].
	clipY ifNil:[clipY := 0].
	clipWidth ifNil:[clipWidth := destForm width].
	clipHeight ifNil:[clipHeight := destForm height].

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
	sourceForm ifNotNil:[
		sx < 0
			ifTrue: [dx _ dx - sx.
					bbW _ bbW + sx.
					sx _ 0].
		sx + bbW > sourceForm width
			ifTrue: [bbW _ bbW - (sx + bbW - sourceForm width)].
		sy < 0
			ifTrue: [dy _ dy - sy.
					bbH _ bbH + sy.
					sy _ 0].
		sy + bbH > sourceForm height
			ifTrue: [bbH _ bbH - (sy + bbH - sourceForm height)].
	].
	(bbW <= 0 or:[bbH <= 0]) ifTrue:[
		sourceX := sourceY := destX := destY := clipX := clipY := width := height := 0.
		^true].
	(sx = sourceX 
		and:[sy = sourceY 
		and:[dx = destX 
		and:[dy = destY 
		and:[bbW = width 
		and:[bbH = height]]]]]) ifTrue:[^false].
	sourceX := sx.
	sourceY := sy.
	destX := dx.
	destY := dy.
	width := bbW.
	height := bbH.
	^true