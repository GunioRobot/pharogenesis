buildFormView: anInspector
	"Build a view which will show a form in the right side of the Inspector.   6/28/96 sw"

	| inspectFormView |

	inspectFormView _ FormInspectView new.
	inspectFormView model: anInspector.
	inspectFormView window: (0 @ 0 extent: 75 @ 40).
	inspectFormView borderWidthLeft: 2 right: 2 top: 2 bottom: 2.
	^ inspectFormView