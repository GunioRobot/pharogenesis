colors: colorList
	"Set my color palette to the given collection."

	| colorArray colorCount newColors |
	colorList ifNil: [
		colors _ cachedDepth _ cachedColormap _ nil.
		^ self].

	colorArray _ colorList asArray.
	colorCount _ colorArray size.
	newColors _ Array new: (1 bitShift: depth).
	1 to: newColors size do: [:i |
		i <= colorCount
			ifTrue: [newColors at: i put: (colorArray at: i)]
			ifFalse: [newColors at: i put: Color transparent]].

	colors _ newColors.
	cachedDepth _ nil.
	cachedColormap _ nil.
