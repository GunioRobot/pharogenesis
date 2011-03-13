open: aTextCollector label: aString 
	"Answer an instance of me on the argument, aTextCollector. The
	label of the StandardSystemView should be aString."
	| topView aView |
	topView _ StandardSystemView new.
	topView model: aTextCollector.
	topView label: aString.
	topView minimumSize: 100 @ 50.
	aView _ self new model: aTextCollector.
	aView borderWidth: 2.
	topView addSubView: aView.
	topView controller open