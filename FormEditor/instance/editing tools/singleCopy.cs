singleCopy 
	"If the red button is clicked, copy the source form onto the display 
	screen."

   (BitBlt destForm: Display
           sourceForm: form halftoneForm: color
           combinationRule: (Display depth > 1 ifTrue: [mode ~= Form erase ifTrue: [Form paint] ifFalse: [mode]]
                                                     ifFalse: [mode])
           destOrigin: self cursorPoint sourceOrigin: 0@0 extent: form extent
           clipRect: view insetDisplayBox)
           colorMap: (Bitmap with: 0 with: 16rFFFFFFFF);
	copyBits.
	sensor waitNoButton.
	hasUnsavedChanges contents: true.