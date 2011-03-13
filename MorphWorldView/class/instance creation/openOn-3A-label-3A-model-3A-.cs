openOn: aWorldMorph label: aString model: aModel
	"Open a view with the given label on the given WorldMorph."
	| topView |
	topView _ self fullColorWhenInactive
		ifTrue: [topView _ ColorSystemView new]
		ifFalse: [topView _ StandardSystemView new].
	topView model: aModel;
		label: aString;
		borderWidth: 1;
		"minimumSize: aWorldMorph extent + (2@2); " "add border width"
		addSubView: (self new initialize model: aWorldMorph);
		backgroundColor: aWorldMorph color.
	topView controller open.
