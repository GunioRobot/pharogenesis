warpPickSourcePixels: nPixels
	xDeltah: xDeltah yDeltah: yDeltah
	xDeltav: xDeltav yDeltav: yDeltav
	"Pick n pixels from the source form,
	map by colorMap and return aligned by dstBitShift.
	This version is only called from WarpBlt with smoothingCount = 1"
	| dstMask destWord nPix sourcePix destPix |
	self inline: true. "Yepp - this should go into warpLoop"
	dstMask _ maskTable at: destPixSize.
	destWord _ 0.
	nPix _ nPixels.
	[
		"Pick a single pixel"
		sourcePix _ self pickWarpPixelAtX: sx y: sy.
		destPix _ sourcePix.
		sourcePixSize > 8 ifTrue:["Color map RGB pix"
			cmDeltaBits = 0 ifFalse:[ "but only if necessary"
				destPix _ self rgbMap: sourcePix.
				(destPix = 0 and:[sourcePix ~= 0]) ifTrue:[destPix _ 1]]].
		"map by colormap if necessary"
		colorMap == nil
			ifFalse:[destPix _ self colormapAt: destPix].
		"Mix it in (note: in theory we could avoid the bitAnd but its safer for now)"
		destWord _ destWord bitOr: (destPix bitAnd: dstMask) << dstBitShift.
		dstBitShift _ dstBitShift - destPixSize.
		sx _ sx + xDeltah.
		sy _ sy + yDeltah.
	(nPix _ nPix - 1) = 0] whileFalse.

	"*** side effect ***"
	"*** only the first pixel fetch can be unaligned ***"
	"*** prepare the next one for aligned access ***"
	dstBitShift _ 32 - destPixSize. "Shift towards leftmost pixel"

	^destWord
