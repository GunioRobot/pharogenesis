erasePrep
	"Transparent paint, square brush.  Be careful not to let this be undone by asking palette for brush and color."

	| size |
	size _ palette getNib width.
	brush _ Form extent: size@size depth: 1.
	brush offset: (0@0) - (brush extent // 2).
	brush fillWithColor: Color black.
	paintingFormPen sourceForm: brush.
	"transparent"
	paintingFormPen combinationRule: Form erase1bitShape.
	paintingFormPen color: Color black.
