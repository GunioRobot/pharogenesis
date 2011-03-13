showColors
	" 
	BlueSmallLandColorTheme new showColors. 
	"
	| col |
	col := AlignmentMorph newColumn.
	col color: Color white.
	col
		addMorphBack: (self rowOf: darks).
	col
		addMorphBack: (self rowOf: normals).
	col
		addMorphBack: (self rowOf: lights).
	""
	col openInWorld