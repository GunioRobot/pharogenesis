fixUpColorPicker
	| chart picker |
	chart _ ColorChart ifNil:[Cursor wait showWhile:[ColorChart _ (Color colorPaletteForDepth: 32 extent: (360+10)@(180+10))]].
	chart getCanvas frameRectangle: chart boundingBox color: Color black.
	picker _ Form extent: (chart extent + (14@12)) depth: 32.
	picker fillWhite.
	"top"
	false ifTrue: [picker copy: (0@0 extent: picker width@6)
			from: (colorMemory image width - picker width)@0 
			in: colorMemory image rule: Form over.
	"bottom"
	picker copy: (0@ (picker height-6) extent: picker width@6) 
			from: (colorMemory image width - picker width)@(colorMemory image height - 7)
			in: colorMemory image rule: Form over.
	"left"
	picker copy: (0@6 corner: 8@(picker height - 6))
			from: (colorMemory image boundingBox topLeft + (0@6)) 
			in: colorMemory image rule: Form over.
	"right"
	picker copy: (picker width-6@6 corner: picker width@(picker height - 6))
			from: (colorMemory image boundingBox topRight - (6@-6)) 
			in: colorMemory image rule: Form over.].
	chart displayOn: picker at: 8@6.
	picker getCanvas frameRectangle: picker boundingBox color: Color black.
	colorMemory image: picker.
