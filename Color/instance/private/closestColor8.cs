closestColor8
	"Return the nearest approximation to this color for an 8-bit deep Form."

	 ^ IndexedColors at: (self closestPixelValue8)+1