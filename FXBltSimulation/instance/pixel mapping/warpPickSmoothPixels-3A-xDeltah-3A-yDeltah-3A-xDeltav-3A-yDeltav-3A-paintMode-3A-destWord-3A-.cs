warpPickSmoothPixels: nPixels
	xDeltah: xDeltah yDeltah: yDeltah
	xDeltav: xDeltav yDeltav: yDeltav
	paintMode: paintMode destWord: destinationWord
	"Pick n (sub-) pixels from the source form, mapped by sourceMap,
	average the RGB values, map by colorMap and return the new word.
	This version is only called from WarpBlt with smoothingCount > 1"
	| rgb x y a r g b xx yy xdh ydh xdv ydv 
	dstMask destWord i j k nPix pv n ptX ptY |
	self inline: false. "nope - too much stuff in here"
	n _ warpQuality.
	n = 2 "Try avoiding divides for most common n (divide by 2 is generated as shift)"
		ifTrue:[xdh _ xDeltah // 2. ydh _ yDeltah // 2. 
				xdv _ xDeltav // 2. ydv _ yDeltav // 2]
		ifFalse:[xdh _ xDeltah // n. ydh _ yDeltah // n. 
				xdv _ xDeltav // n. ydv _ yDeltav // n].
	dstMask _ maskTable at: destDepth.
	destWord _ 0.
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
				"get a single subpixel if not clipped"
				(xx < 0 or:[yy < 0 or:[
					(ptX _ xx >> BinaryPoint) >= sourceWidth or:[
						(ptY _ yy >> BinaryPoint) >= sourceHeight]]]) ifFalse:[
				pv _ self pickWarpPixelAtX: ptX y: ptY.
				(paintMode and: [pv = sourceAlphaKey]) ifFalse:[
					"If not clipped and not transparent, then tally rgb values"
					nPix _ nPix + 1.
					rgb _ self mapSourcePixel: pv.
					b _ b + (rgb bitAnd: 255).
					g _ g + (rgb >> 8 bitAnd: 255).
					r _ r + (rgb >> 16 bitAnd: 255).
					a _ a + (rgb >> 24)]].
				xx _ xx + xdh.
				yy _ yy + ydh.
			(k _ k - 1) = 0] whileFalse.
			x _ x + xdv.
			y _ y + ydv.
		(j _ j - 1) = 0] whileFalse.

		(nPix = 0 or: [paintMode and: [nPix < (n * n // 2)]]) ifTrue:[
			nPix _ pv _ 0  "All pixels were 0, or most were transparent"
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
			pv _ self mapPixel: rgb.
		].
		"Mix it in"
		nPix = 0 
			ifTrue:[destWord _ destWord bitOr: (destinationWord bitAnd: (dstMask << dstBitShift))]
			ifFalse:[destWord _ destWord bitOr: (pv bitAnd: dstMask) << dstBitShift].
		destMSB
			ifTrue:[dstBitShift _ dstBitShift - destDepth]
			ifFalse:[dstBitShift _ dstBitShift + destDepth].
		sx _ sx + xDeltah.
		sy _ sy + yDeltah.
	(i _ i - 1) = 0] whileFalse.

	"*** side effect ***"
	"*** only the first pixel fetch can be unaligned ***"
	"*** prepare the next one for aligned access ***"
	destMSB "Shift towards leftmost pixel"
		ifTrue:[dstBitShift _ 32 - destDepth]
		ifFalse:[dstBitShift _ 0].
	^destWord