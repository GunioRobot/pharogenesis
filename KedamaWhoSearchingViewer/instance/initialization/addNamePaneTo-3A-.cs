addNamePaneTo: header
	"Add the namePane, which may be a popup or a type-in depending on the type of CategoryViewer"

	| plugTextMor searchButton |
	namePane _ AlignmentMorph newRow vResizing: #spaceFill; height: 14.
	namePane hResizing: #spaceFill.
	namePane listDirection: #leftToRight.

	plugTextMor _ PluggableTextMorph on: self
					text: #searchString accept: #searchString:notifying:
					readSelection: nil menu: nil.
	plugTextMor setProperty: #alwaysAccept toValue: true.
	plugTextMor askBeforeDiscardingEdits: false.
	plugTextMor acceptOnCR: true.
	plugTextMor setTextColor: Color brown.
	plugTextMor setNameTo: 'Turtle' translated.
	plugTextMor vResizing: #spaceFill; hResizing: #spaceFill.
	plugTextMor hideScrollBarsIndefinitely.
	plugTextMor setTextMorphToSelectAllOnMouseEnter.

	searchButton _ SimpleButtonMorph new 
		target: self;
		beTransparent;
		label: 'Turtle' translated;
		actionSelector: #doSearchFrom:;
		arguments: {plugTextMor}.
	searchButton setBalloonText: 'Type a number into the pane to specify the individual turtle.' translated.

	namePane addMorphFront: searchButton.
	namePane addTransparentSpacerOfSize: 6@0.
	namePane addMorphBack: plugTextMor.
	header addMorphBack: namePane