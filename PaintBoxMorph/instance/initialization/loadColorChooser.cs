loadColorChooser
	"Go to bitmap-backed ColorMemoryMorph, Load its picture, load the underlying picture."

| form doc |
(Smalltalk at: #AA ifAbsent: [nil]) class == Form 
	ifFalse: ["read for first time"
		doc _ Utilities objectStrmFromUpdates: 'colorPalClosed.obj'.
		Smalltalk at: #AA put: doc fileInObjectAndCode.
		doc _ Utilities objectStrmFromUpdates: 'colorPalOpen.obj'.
		Smalltalk at: #BB put: doc fileInObjectAndCode].

form _ (Smalltalk at: #AA) removeZeroPixelsFromForm.	"Make black be black, not transparent"
colorMemoryThin image: form.
colorMemoryThin position: self position + (0@140).

"Install the color memory bitmap"
colorMemory delete.	"old"
colorMemory _ ColorMemory2Morph new initialize.
colorMemory on: #mouseUp send: #click: to: colorMemory.
		"it sends takeColorEvt:from: to me"
"form _ Form newFromFileNamed: 'openPalette.form'. old, from local disk"
form _ (Smalltalk at: #BB) removeZeroPixelsFromForm.	"Make black be black, not transparent"
colorMemory image: form.
colorMemory on: #mouseLeave send: #delete to: colorMemory.