getBrightness
	"Returns the brightness of the light as a value between 0 and 1."

	^ ((myColor red) max: (myColor green)) max: (myColor blue).
