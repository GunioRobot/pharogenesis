colormapAt: idx
	"Return the word at position idx from the colorMap"
	^interpreterProxy longAt: colorMap + (idx << 2)