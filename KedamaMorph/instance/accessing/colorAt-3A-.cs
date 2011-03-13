colorAt: aLocalPoint

	| pix |
	pix _ patchVarDisplayForm pixelValueAt: (aLocalPoint // pixelsPerPatch) asIntegerPoint.
	^ Color colorFromPixelValue: (pix bitOr: 16rFF000000) depth: 32.
