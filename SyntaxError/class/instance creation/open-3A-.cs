open: aSyntaxError
	"Answer a standard system view whose model is an instance of me.  TK 15 May 96"
	|  topView aListView aCodeView |
	topView _ StandardSystemView new.
	topView model: aSyntaxError.
	topView label: 'Syntax Error'.
	topView minimumSize: 380 @ 220.
	aListView _ SyntaxErrorListView new.
	aListView model: aSyntaxError.
	aListView window: (0 @ 0 extent: 380 @ 20).
	aListView
		borderWidthLeft: 2
		right: 2
		top: 2
		bottom: 0.
	topView addSubView: aListView.
	aCodeView _ BrowserCodeView new.
	aCodeView model: aSyntaxError.
	aCodeView window: (0 @ 0 extent: 380 @ 200).
	aCodeView
		borderWidthLeft: 2
		right: 2
		top: 2
		bottom: 2.
	topView
		addSubView: aCodeView
		align: aCodeView viewport topLeft
		with: aListView viewport bottomLeft.
	topView controller openNoTerminateDisplayAt: Display extent // 2.
	Cursor normal show.
	Processor activeProcess suspend