checkExtent: newExtent 
	| pixPerTick newWidth |
	pixPerTick _ newExtent x - (self borderWidth * 2) - 1 / ((stop - start) asFloat / minorTick).
	pixPerTick _ pixPerTick
				detentBy: 0.1
				atMultiplesOf: 1.0
				snap: false.
	newWidth _ pixPerTick * ((stop - start) asFloat / minorTick) + (self borderWidth * 2) + 1.
	^ (newWidth @ newExtent y).