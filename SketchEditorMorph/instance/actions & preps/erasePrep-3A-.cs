erasePrep: evt
	"Transparent paint, square brush.  Be careful not to let this be undone by asking palette for brush and color."

	| size pfPen myBrush |

	pfPen _ self get: #paintingFormPen for: evt.
	size _ (self getNibFor: evt) width.
	self set: #brush for: evt to: (myBrush _ Form extent: size@size depth: 1).
	myBrush offset: (0@0) - (myBrush extent // 2).
	myBrush fillWithColor: Color black.
	pfPen sourceForm: myBrush.
	"transparent"
	pfPen combinationRule: Form erase1bitShape.
	pfPen color: Color black.
