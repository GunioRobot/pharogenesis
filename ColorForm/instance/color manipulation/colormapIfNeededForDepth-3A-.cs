colormapIfNeededForDepth: destDepth
	"Return a colormap for displaying the receiver at the given depth, or nil if no colormap is needed."

	| newMap |
	colors == nil ifTrue: [
		"use the standard colormap"
		^ Color colorMapIfNeededFrom: self depth to: destDepth].

	(destDepth = cachedDepth and:[cachedColormap isColormap not]) 
		ifTrue: [^ cachedColormap].
	newMap _ Bitmap new: colors size.
	1 to: colors size do: [:i |
		newMap
			at: i
			put: ((colors at: i) pixelValueForDepth: destDepth)].

	cachedDepth _ destDepth.
	^ cachedColormap _ newMap.
