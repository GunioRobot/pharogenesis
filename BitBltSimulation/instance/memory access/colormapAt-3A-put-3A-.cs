colormapAt: idx put: value
	"Store the word at position idx in the colorMap"
	^interpreterProxy longAt: colorMap + (idx << 2) put: value