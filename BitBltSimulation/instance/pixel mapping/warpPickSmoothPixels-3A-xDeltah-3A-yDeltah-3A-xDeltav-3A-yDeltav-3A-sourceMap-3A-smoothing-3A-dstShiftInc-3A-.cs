warpPickSmoothPixels: nPixels
	xDeltah: xDeltah yDeltah: yDeltah
	xDeltav: xDeltav yDeltav: yDeltav
	sourceMap: sourceMap
	smoothing: n
	dstShiftInc: dstShiftInc
	"Pick n (sub-) pixels from the source form, mapped by sourceMap,
	average the RGB values, map by colorMap and return the new word.
	This version is only called from WarpBlt with smoothingCount > 1"
	| rgb x y a r g b xx yy xdh ydh xdv ydv dstMask destWord i j k nPix |
	self inline: false. "nope - too much stuff in here"
	dstMask _ maskTable at: destDepth.
	destWord _ 0.
	n = 2 "Try avoiding divides for most common n (divide by 2 is generated as shift)"
		ifTrue:[xdh _ xDeltah // 2. ydh _ yDeltah // 2. 
				xdv _ xDeltav // 2. ydv _ yDeltav // 2]
		ifFalse:[xdh _ xDeltah // n. ydh _ yDeltah // n. 
				xdv _ xDeltav // n. ydv _ yDeltav // n].
	i _ nPixels.
	[
		x _ sx. y _ sy.
		a _ r _ g _ b _ 0.
		"Pick and average n*n subpixels"
		nPix _ 0.  "actual number of pixels (not clipped and not transparent)"
		j _ n.
		[
			xx _ x. yy _ y.
			k _ n.
			[
				"get a single subpixel"
				rgb _ self pickWarpPixelAtX: xx y: yy.
				(combinationRule=25 "PAINT" and: [rgb = 0]) ifFalse:[
					"If not clipped and not transparent, then tally rgb values"
					nPix _ nPix + 1.
					sourceDepth < 16 ifTrue:[
						"Get RGBA values from sourcemap table"
						rgb _ interpreterProxy longAt: sourceMap + (rgb << 2).
					] ifFalse:["Already in RGB format"
						sourceDepth = 16 
								ifTrue:[rgb _ self rgbMap16To32: rgb]
								ifFalse:[rgb _ self rgbMap32To32: rgb]].
					b _ b + (rgb bitAnd: 255).
					g _ g + (rgb >> 8 bitAnd: 255).
					r _ r + (rgb >> 16 bitAnd: 255).
					a _ a + (rgb >> 24)].
				xx _ xx + xdh.
				yy _ yy + ydh.
			(k _ k - 1) = 0] whileFalse.
			x _ x + xdv.
			y _ y + ydv.
		(j _ j - 1) = 0] whileFalse.

		(nPix = 0 or: [combinationRule=25 "PAINT" and: [nPix < (n * n // 2)]]) ifTrue:[
			rgb _ 0  "All pixels were 0, or most were transparent"
		] ifFalse:[
			"normalize rgba sums"
			nPix = 4 "Try to avoid divides for most common n"
				ifTrue:[r _ r >> 2.	g _ g >> 2.	b _ b >> 2.	a _ a >> 2]
				ifFalse:[	r _ r // nPix.	g _ g // nPix.	b _ b // nPix.	a _ a // nPix].
			rgb _ (a << 24) + (r << 16) + (g << 8) + b.

			"map the pixel"
			rgb = 0 ifTrue: [
				"only generate zero if pixel is really transparent"
				(r + g + b + a) > 0 ifTrue: [rgb _ 1]].
			rgb _ self mapPixel: rgb flags: cmFlags.
		].
		"Mix it in"
		destWord _ destWord bitOr: (rgb bitAnd: dstMask) << dstBitShift.
		dstBitShift _ dstBitShift + dstShiftInc.
		sx _ sx + xDeltah.
		sy _ sy + yDeltah.
	(i _ i - 1) = 0] whileFalse.

	^destWord
