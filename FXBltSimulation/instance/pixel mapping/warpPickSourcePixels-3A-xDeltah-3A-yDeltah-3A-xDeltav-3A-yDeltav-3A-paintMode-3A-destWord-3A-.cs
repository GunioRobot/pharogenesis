warpPickSourcePixels: nPixels
	xDeltah: xDeltah yDeltah: yDeltah
	xDeltav: xDeltav yDeltav: yDeltav
	paintMode: paintMode destWord: destinationWord
	"Pick n pixels from the source form,
	map by colorMap and return aligned by dstBitShift.
	This version is only called from WarpBlt with smoothingCount = 1"
	| dstMask resultWord nPix sourcePix mappedPix lastPix x y hasPix |
	self inline: true. "This should go into warpLoop"
	dstMask _ maskTable at: destDepth.
	resultWord _ 0.
	nPix _ nPixels.
	"Pick and map first pixel to avoid color conversion"
	lastPix _ 0.
	hasPix _ false.
	(sx < 0 or:[sy < 0 or:[
		(x _ sx >> BinaryPoint) >= sourceWidth or:[
			(y _ sy >> BinaryPoint) >= sourceHeight]]]) ifFalse:[
				lastPix _ sourcePix _ self pickWarpPixelAtX: x y: y.
				(paintMode and:[sourcePix = sourceAlphaKey])
					ifFalse:[hasPix _ true]].
	"Note: lastPix might be zero here but who cares..."
	mappedPix _ self mapPixel: lastPix.
	["Mix it in"
	hasPix
		ifTrue:[resultWord _ resultWord bitOr: 
					(mappedPix bitAnd: dstMask) << dstBitShift]
		ifFalse:[resultWord _ resultWord bitOr: 
					(destinationWord bitAnd: (dstMask << dstBitShift))].
	destMSB
		ifTrue:[dstBitShift _ dstBitShift - destDepth]
		ifFalse:[dstBitShift _ dstBitShift + destDepth].
	sx _ sx + xDeltah.
	sy _ sy + yDeltah.
	(nPix _ nPix - 1) = 0] whileFalse:["Pick and map next pixel"
		hasPix _ false.
		(sx < 0 or:[sy < 0 or:[
			(x _ sx >> BinaryPoint) >= sourceWidth or:[
				(y _ sy >> BinaryPoint) >= sourceHeight]]]) ifFalse:[
			sourcePix _ self pickWarpPixelAtX: x y: y.
			(paintMode and:[sourcePix = sourceAlphaKey]) ifFalse:[
				hasPix _ true.
				lastPix = sourcePix ifFalse:[
					"map the pixel(either into colorMap or destFormat)"
					mappedPix _ self mapPixel: sourcePix.
					lastPix _ sourcePix]]].
	].
	"*** side effect ***"
	"*** only the first pixel fetch can be unaligned ***"
	"*** prepare the next one for aligned access ***"
	destMSB "Shift towards leftmost pixel"
		ifTrue:[dstBitShift _ 32 - destDepth]
		ifFalse:[dstBitShift _ 0].
	^resultWord