colormapIfNeededForDepth: destDepth
	"Return a colormap for displaying the receiver at the given depth, or nil if no colormap is needed."

	| newMap |
	colors == nil ifTrue: [
		"use the standard colormap"
		^ Color colorMapIfNeededFrom: depth to: destDepth].

	destDepth = cachedDepth ifTrue: [^ cachedColormap].
	newMap _ Bitmap new: colors size.
	1 to: colors size do: [:i |
		newMap
			at: i
			put: ((colors at: i) pixelValueForDepth: destDepth)].

	cachedDepth _ destDepth.
	^ cachedColormap _ newMap.
