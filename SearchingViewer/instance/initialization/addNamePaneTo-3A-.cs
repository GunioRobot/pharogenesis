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
	plugTextMor setNameTo: 'Search' translated.
	plugTextMor vResizing: #spaceFill; hResizing: #spaceFill.
	plugTextMor hideScrollBarsIndefinitely.
	plugTextMor setTextMorphToSelectAllOnMouseEnter.

	searchButton _ SimpleButtonMorph new 
		target: self;
		beTransparent;
		label: 'Search' translated;
		actionSelector: #doSearchFrom:;
		arguments: {plugTextMor}.
	searchButton setBalloonText: 'Type some letters into the pane at right, and then press this Search button (or hit RETURN) and all method selectors that match what you typed will appear in the list below.' translated.

	namePane addMorphFront: searchButton.
	namePane addTransparentSpacerOfSize: 6@0.
	namePane addMorphBack: plugTextMor.
	header addMorphBack: namePane