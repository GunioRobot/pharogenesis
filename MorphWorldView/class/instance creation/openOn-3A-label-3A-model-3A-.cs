openOn: aWorldMorph label: aString model: aModel 
	"Open a view with the given label on the given WorldMorph."

	| topView |
	topView := self fullColorWhenInactive 
				ifTrue: [topView := ColorSystemView new]
				ifFalse: [topView := StandardSystemView new].
	topView
		model: aModel;
		label: aString;
		borderWidth: 1;
		addSubView: (self new model: aWorldMorph);
		backgroundColor: aWorldMorph color.
	"minimumSize: aWorldMorph extent + (2@2); "	"add border width"
	topView controller open