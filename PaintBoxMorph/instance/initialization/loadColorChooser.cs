loadColorChooser
	"Load Forms for ColorMemoryMorph."

	| doc closedForm openForm |
	doc _ Utilities objectStrmFromUpdates: 'colorPalClosed.obj'.
	closedForm _ doc fileInObjectAndCode mapColor: Color transparent to: Color black.
	doc _ Utilities objectStrmFromUpdates: 'colorPalOpen.obj'.
	openForm _ doc fileInObjectAndCode mapColor: Color transparent to: Color black.

	colorMemoryThin image: closedForm.
	colorMemoryThin position: self position + (0@140).

	colorMemory delete.	"delete old one"
	colorMemory _ PaintBoxColorPicker new image: openForm.
