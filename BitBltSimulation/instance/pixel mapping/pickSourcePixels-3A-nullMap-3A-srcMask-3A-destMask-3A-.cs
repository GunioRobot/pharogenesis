pickSourcePixels: nPixels nullMap: nullMap srcMask: srcMask destMask: dstMask
	"Pick nPix pixels starting at srcBitIndex from the source, map by the
	color map, and justify them according to dstBitIndex in the resulting destWord.
	Incoming pixels of 16 or 32 bits are first reduced to cmBitsPerColor.
	With no color map, pixels are just masked or zero-filled or
	if 16- or 32-bit pixels, the r, g, and b are so treated individually."
	"ar 12/7/1999:
	- the method currently has a side effect (see at the end)
	- the idea is to inline this into a single sender and do 
	most of the color space stuff here
	- the '[...] whileFalse' is intended to generate 
	'do { ... } while(...)' loops which are faster"
	| sourceWord destWord sourcePix destPix srcShift dstShift nPix |
	self inline: true. "oh please"
	sourceWord _ self srcLongAt: sourceIndex.
	destWord _ 0.
	srcShift _ srcBitShift. "Hint: Keep in register"
	dstShift _ dstBitShift. "Hint: Keep in register"
	nPix _ nPixels. "always > 0 so we can use do { } while(--nPix);"
	(nullMap or:[sourcePixSize > 8]) ifTrue:[
		"Extract the degenerate case of sourcePixSize <= 8 and nullMap.
		Note: The case is considered degenerate because there should always
		be a colormap when copying between indexed color forms of differing depth."
		sourcePixSize <= 8 ifTrue:[
			"Degenerate so the dirty version w/o comments..."
			[destWord _ destWord bitOr: 
				((sourceWord >> srcShift bitAnd: srcMask) bitAnd: dstMask) << dstShift.
			dstShift _ dstShift - destPixSize.
			(srcShift _ srcShift - sourcePixSize) < 0 ifTrue:
				[srcShift _ srcShift + 32.
				sourceWord _ self srcLongAt: (sourceIndex _ sourceIndex + 4)].
			(nPix _ nPix - 1) = 0] whileFalse.
		] ifFalse:["sourcePixSize > 8"
			"Convert RGB pixels. Since the cmMasks and cmShifts have been
			setup initially we only need one version here."
			["pick source pixel"
			sourcePix _ sourceWord >> srcShift bitAnd: srcMask.
			"map the pixel(either into colorMap or destFormat)"
			cmDeltaBits = 0 "e.g., srcFormat == dstFormat"
				ifTrue:[destPix _ sourcePix]
				ifFalse:[	destPix _ self rgbMap: sourcePix.
						"Avoid transparency by color conversion"
						(destPix = 0 and:[sourcePix ~= 0]) ifTrue:[destPix _ 1]].
			"if nullMap == false do colormap lookup after color reduction"
			nullMap ifFalse:[destPix _ self colormapAt: destPix].
			"Mix it in (note: in theory we could avoid the bitAnd but its safer for now)"
			destWord _ destWord bitOr: (destPix bitAnd: dstMask) << dstShift.
			dstShift _ dstShift - destPixSize.
			"Adjust source if at pixel boundary"
			(srcShift _ srcShift - sourcePixSize) < 0 ifTrue:
				[srcShift _ srcShift + 32.
				sourceWord _ self srcLongAt: (sourceIndex _ sourceIndex + 4)].
			(nPix _ nPix - 1) = 0] whileFalse.
		].
	] ifFalse:[
		"This part executed if we have a source pix size <= 8
		and a colormap lookup as in the regular text display."
		[
			"pick source pixel"
			sourcePix _ sourceWord >> srcShift bitAnd: srcMask.
			"Map it by color map"
			destPix _ (self colormapAt: sourcePix) bitAnd: dstMask.
			"**** How do we find out if we have to do color space conversion here ****"
			"Mix it in"
			destWord _ destWord bitOr: destPix << dstShift.
			"adjust shift"
			dstShift _ dstShift - destPixSize.
			"Adjust source if at pixel boundary"
			(srcShift _ srcShift - sourcePixSize) < 0 ifTrue:
				[srcShift _ srcShift + 32.
				sourceWord _ self srcLongAt: (sourceIndex _ sourceIndex + 4)].
		(nPix _ nPix - 1) = 0] whileFalse.
	].
	srcBitShift _ srcShift. "Store back"
	"*** side effect ***"
	"*** only the first pixel fetch can be unaligned ***"
	"*** prepare the next one for aligned access ***"
	dstBitShift _ 32 - destPixSize. "Shift towards leftmost pixel"
	^destWord