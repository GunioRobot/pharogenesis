warpPickSourcePixels: nPixels
	xDeltah: xDeltah yDeltah: yDeltah
	xDeltav: xDeltav yDeltav: yDeltav
	dstShiftInc: dstShiftInc
	flags: mapperFlags
	"Pick n pixels from the source form,
	map by colorMap and return aligned by dstBitShift.
	This version is only called from WarpBlt with smoothingCount = 1"
	| dstMask destWord nPix sourcePix destPix |
	self inline: true. "Yepp - this should go into warpLoop"
	dstMask _ maskTable at: destDepth.
	destWord _ 0.
	nPix _ nPixels.
	(mapperFlags = (ColorMapPresent bitOr: ColorMapIndexedPart)) ifTrue:[
		"a little optimization for (pretty crucial) blits using indexed lookups only"
		[	"grab, colormap and mix in pixel"
			sourcePix _ self pickWarpPixelAtX: sx y: sy.
			destPix _ cmLookupTable at: (sourcePix bitAnd: cmMask).
			destWord _ destWord bitOr: (destPix bitAnd: dstMask) << dstBitShift.
			dstBitShift _ dstBitShift + dstShiftInc.
			sx _ sx + xDeltah.
			sy _ sy + yDeltah.
		(nPix _ nPix - 1) = 0] whileFalse.
	] ifFalse:[
		[	"grab, colormap and mix in pixel"
			sourcePix _ self pickWarpPixelAtX: sx y: sy.
			destPix _ self mapPixel: sourcePix flags: mapperFlags.
			destWord _ destWord bitOr: (destPix bitAnd: dstMask) << dstBitShift.
			dstBitShift _ dstBitShift + dstShiftInc.
			sx _ sx + xDeltah.
			sy _ sy + yDeltah.
		(nPix _ nPix - 1) = 0] whileFalse.
	].
	^destWord
