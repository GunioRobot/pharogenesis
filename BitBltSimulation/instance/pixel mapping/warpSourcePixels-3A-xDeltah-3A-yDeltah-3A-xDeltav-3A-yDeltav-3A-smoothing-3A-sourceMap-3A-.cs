warpSourcePixels: nPix xDeltah: xDeltah yDeltah: yDeltah
	xDeltav: xDeltav yDeltav: yDeltav
	smoothing: n sourceMap: sourceMapOop
	"Pick nPix pixels using these x- and y-incs, and map color if necess."

	| destWord sourcePix sourcePixMask destPixMask srcPixPerWord destPix |
	self inline: false.
	sourcePixMask _ maskTable at: sourcePixSize.
	destPixMask _ maskTable at: destPixSize.
	srcPixPerWord _ 32 // sourcePixSize.
	destWord _ 0.
	1 to: nPix do:
		[:i |
		n > 1
		ifTrue:
			["Average n pixels and compute dest pixel from color map"
			destPix _ (self smoothPix: n atXf: sx yf: sy
				dxh: xDeltah//n dyh: yDeltah//n dxv: xDeltav//n dyv: yDeltav//n
				pixPerWord: srcPixPerWord pixelMask: sourcePixMask
				sourceMap: sourceMapOop)
					bitAnd: destPixMask]
		ifFalse:
			["No smoothing -- just pick pixel and map if difft depths or color map supplied"
			sourcePix _ (self sourcePixAtX: sx >> BinaryPoint
									y: sy >> BinaryPoint
									pixPerWord: srcPixPerWord)
						bitAnd: sourcePixMask.
			colorMap = nil
				ifTrue:
				[destPixSize = sourcePixSize
				ifTrue:
					[destPix _ sourcePix]
				ifFalse:
					[sourcePixSize >= 16 ifTrue:
						["Map between RGB pixels"
						sourcePixSize = 16
							ifTrue: [destPix _ self rgbMap: sourcePix from: 5 to: 8]
							ifFalse: [destPix _ self rgbMap: sourcePix from: 8 to: 5]]
					ifFalse: [destPix _ sourcePix bitAnd: destPixMask]]]
			ifFalse:
				[sourcePixSize >= 16 ifTrue:
					["RGB pixels first get reduced to cmBitsPerColor"
					sourcePixSize = 16
						ifTrue: [sourcePix _ self rgbMap: sourcePix from: 5 to: cmBitsPerColor]
						ifFalse: [sourcePix _ self rgbMap: sourcePix from: 8 to: cmBitsPerColor]].
				"Then look up sourcePix in colorMap"
				destPix _ (self colormapAt: sourcePix) bitAnd: destPixMask]].
		destPixSize = 32
			ifTrue:[destWord _ destPix]
			ifFalse:[destWord _ (destWord << destPixSize) bitOr: destPix].
		sx _ sx + xDeltah.
		sy _ sy + yDeltah.
		].
	^ destWord