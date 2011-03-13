initializeGrayToIndexMap
	"Build an array of gray values available in the fixed colormap. This array is used
	 to map from a pixel value back to its color."
	"Note: This must be called after initializeIndexedColors, since it uses IndexedColors."
	"Color initializeGrayToIndexMap"

	| grayLevels grayIndices c distToClosest dist indexOfClosest |
	"record the level and index of each gray in the 8-bit color table"
	grayLevels _ OrderedCollection new.
	grayIndices _ OrderedCollection new.
	1 to: IndexedColors size do: [ :i |
		c _ IndexedColors at: i.
		c saturation = 0.0 ifTrue: [
			grayLevels add: (c privateBlue) >> 2.
			grayIndices add: i - 1.  "hardward colormap is 0-based"
		].
	].
	grayLevels _ grayLevels asArray.
	grayIndices _ grayIndices asArray.

	"for each gray level in [0..255], select the closest match"
	GrayToIndexMap _ ByteArray new: 256.
	0 to: 255 do: [ :level |
		distToClosest _ 10000.  "greater than distance to any real gray"
		1 to: grayLevels size do: [ :i |
			dist _ (level - (grayLevels at: i)) abs.
			dist < distToClosest ifTrue: [
				distToClosest _ dist.
				indexOfClosest _ grayIndices at: i.
			].
		].
		GrayToIndexMap at: (level + 1) put: indexOfClosest.
	].

	
