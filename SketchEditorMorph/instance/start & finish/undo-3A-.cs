undo: evt
	"revert to a previous state.  "

	| temp poly |

	self flag: #bob.		"what is undo in multihand environment?"
	undoBuffer ifNil: [^ self beep].	"nothing to go back to"
	(poly _ self valueOfProperty: #polygon) ifNotNil:
		[poly delete.
		self setProperty: #polygon toValue: nil.
		^ self].
	temp _ paintingForm.
	paintingForm _ undoBuffer.
	undoBuffer _ temp.		"can get back to what you had by undoing again"
	(self get: #paintingFormPen for: evt) setDestForm: paintingForm.
	formCanvas _ paintingForm getCanvas.	"used for lines, ovals, etc."
	formCanvas _ formCanvas
		copyOrigin: self topLeft negated
		clipRect: (0@0 extent: bounds extent).
	self render: bounds.