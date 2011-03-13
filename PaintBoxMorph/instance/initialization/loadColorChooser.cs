loadColorChooser
	"Load Forms for ColorMemoryMorph."

	| doc closedForm openForm |
	doc := Utilities objectStrmFromUpdates: 'colorPalClosed.obj'.
	closedForm := doc fileInObjectAndCode mapColor: Color transparent to: Color black.
	doc := Utilities objectStrmFromUpdates: 'colorPalOpen.obj'.
	openForm := doc fileInObjectAndCode mapColor: Color transparent to: Color black.

	colorMemoryThin image: closedForm.
	colorMemoryThin position: self position + (0@140).

	colorMemory delete.	"delete old one"
	colorMemory := PaintBoxColorPicker new image: openForm.
