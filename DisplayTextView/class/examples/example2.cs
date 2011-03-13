example2	
	"Create a standarad system view with two parts, one editable, the other not."
	| topView aDisplayTextView |
	topView := StandardSystemView new.
	topView label: 'Text Editor'.
	aDisplayTextView := self new model: 'test string label' asDisplayText.
	aDisplayTextView controller: NoController new.
	aDisplayTextView window: (0 @ 0 extent: 100 @ 100).
	aDisplayTextView borderWidthLeft: 2 right: 0 top: 2 bottom: 2.
	topView addSubView: aDisplayTextView.

	aDisplayTextView := self new model: 'test string' asDisplayText.
	aDisplayTextView window: (0 @ 0 extent: 100 @ 100).
	aDisplayTextView borderWidth: 2.
	topView
		addSubView: aDisplayTextView
		align: aDisplayTextView viewport topLeft
		with: topView lastSubView viewport topRight.
	topView controller open

	"DisplayTextView example2"