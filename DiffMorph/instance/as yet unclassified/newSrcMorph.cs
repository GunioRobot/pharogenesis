newSrcMorph
	"Answer a new src text morph."

	^(self newTextEditorFor: nil
		getText: nil
		setText: nil
		getEnabled: nil)
		hideVScrollBarIndefinitely: true;
		borderWidth: 0;
		enabled: false;
		wrapFlag: false;
		selectionColor: self textSelectionColor;
		setText: ''