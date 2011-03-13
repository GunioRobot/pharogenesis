warpBits
	| deltaP12x deltaP12y deltaP43x deltaP43y pAx pAy pBx pBy deltaPABx deltaPABy sx sy bb fixedPt1 d |
	<primitive: 147>
	fixedPt1 _ 16384.  "1.0 in fixed-pt representation"
	d _ height-1 max: 1.
	deltaP12x _ p2x - p1x // d.
	deltaP12y _ p2y - p1y // d.
	deltaP43x _ p3x - p4x // d.
	deltaP43y _ p3y - p4y // d.
	pAx _ p1x.
	pAy _ p1y.
	pBx _ p4x.
	pBy _ p4y.
	d _ width-1 max: 1.
	bb _ BitBlt destForm: destForm sourceForm: sourceForm halftoneForm: nil
		combinationRule: combinationRule destOrigin: 0@0 sourceOrigin: 0@0
		extent: 1@1 clipRect: self clipRect.
	destY to: destY+height-1 do:
		[:y |
		sx _ pAx.
		sy _ pAy.
		deltaPABx _ pBx - pAx // d.
		deltaPABy _ pBy - pAy // d.
		destX to: destX+width-1 do:
			[:x | bb sourceOrigin: (sx//fixedPt1)@(sy//fixedPt1);
					destOrigin: x@y;
					copyBits.
			sx _ sx + deltaPABx.
			sy _ sy + deltaPABy.
			].
		pAx _ pAx + deltaP12x.
		pAy _ pAy + deltaP12y.
		pBx _ pBx + deltaP43x.
		pBy _ pBy + deltaP43y.
		]