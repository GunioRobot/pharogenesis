transparentBorder: aForm
	"Answer an instance of me that looks like aForm,
	but is transparent in regions near the edge."

	| shape colorMap shapeCopy edgeColor figure |
	shape _ Form extent: aForm extent offset: aForm offset.  "Copy the figure 1 bit deep"
	colorMap _ Bitmap new: (1 bitShift: aForm depth) withAll: 1.
	colorMap at: (edgeColor _ aForm peripheralColor) + 1 put: 0.
	shape copyBits: shape boundingBox from: aForm at: 0@0 colorMap: colorMap.
	shapeCopy _ shape deepCopy.
	shape fillPeriphery: (Color black).  "Blacken edge regions"
	shapeCopy displayOn: shape at: 0@0 rule: Form reverse.
	"Now shape is just the edge region"
	edgeColor = 0
		ifTrue: ["The original form can serve as the figure"
				figure _ aForm.
				edgeColor _ nil]
		ifFalse: ["Need to copy the original form and zero the edge
				region if it wasn't a true zero before"
				figure _ aForm deepCopy.
				shape displayOn: figure at: 0@0
					clippingBox: figure boundingBox
					rule: Form erase1bitShape fillColor: nil].
	shape reverse.  "Reverse to get just the inside (non-edge) region"
	^ self new setForm: figure mask: shape 
		removeOverlap: false transpPixVal: edgeColor
 
	"Cursor blank showWhile:
		[(MaskedForm transparentBorder: Form fromUser)
			followCursor]]."