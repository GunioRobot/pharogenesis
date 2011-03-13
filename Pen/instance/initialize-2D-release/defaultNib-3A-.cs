defaultNib: widthInteger 
	"Nib is the tip of a pen. This sets up the pen, with a nib of width
	widthInteger. Alternatively, try
		roundNib: widthInteger, or
		sourceForm: aForm
	to set the shape of the tip. For example, try:
		| bic | bic _ Pen new sourceForm: Cursor normal.
		bic combinationRule: Form paint; turn: 90.
		10 timesRepeat: [bic down; go: 10; up; go: 20].
"
	self color: destForm black.
	self squareNib: widthInteger