inMorphicWindowWithInitialSearchString: initialString
	"Answer a morphic window with the given initial search string, nil if none"

"MessageNames openMessageNames"

	| window selectorListView firstDivider secondDivider horizDivider typeInPane searchButton plugTextMor |
	window _ (SystemWindow labelled: 'Message Names') model: self.
	firstDivider _ 0.07.
	secondDivider _ 0.5.
	horizDivider _ 0.5.
	typeInPane _ AlignmentMorph newRow vResizing: #spaceFill; height: 14.
	typeInPane hResizing: #spaceFill.
	typeInPane listDirection: #leftToRight.

	plugTextMor _ PluggableTextMorph on: self
					text: #searchString accept: #searchString:notifying:
					readSelection: nil menu: nil.
	plugTextMor setProperty: #alwaysAccept toValue: true.
	plugTextMor askBeforeDiscardingEdits: false.
	plugTextMor acceptOnCR: true.
	plugTextMor setTextColor: Color brown.
	plugTextMor setNameTo: 'Search'.
	plugTextMor vResizing: #spaceFill; hResizing: #spaceFill.
	plugTextMor hideScrollBarsIndefinitely.
	plugTextMor setTextMorphToSelectAllOnMouseEnter.

	searchButton _ SimpleButtonMorph new 
		target: self;
		beTransparent;
		label: 'Search';
		actionSelector: #doSearchFrom:;
		arguments: {plugTextMor}.
	searchButton setBalloonText: 'Type some letters into the pane at right, and then press this Search button (or hit RETURN) and all method selectors that match what you typed will appear in the list pane below.  Click on any one of them, and all the implementors of that selector will be shown in the right-hand pane, and you can view and edit their code without leaving this tool.'.

	typeInPane addMorphFront: searchButton.
	typeInPane addTransparentSpacerOfSize: 6@0.
	typeInPane addMorphBack: plugTextMor.
	initialString isEmptyOrNil ifFalse:
		[plugTextMor setText: initialString].

	window addMorph: typeInPane frame: (0@0 corner: horizDivider @ firstDivider).

	selectorListView _ PluggableListMorph on: self
		list: #selectorList
		selected: #selectorListIndex
		changeSelected: #selectorListIndex:
		menu: #selectorListMenu:
		keystroke: #selectorListKey:from:.
	selectorListView menuTitleSelector: #selectorListMenuTitle.
	window addMorph: selectorListView frame: (0 @ firstDivider corner: horizDivider @ secondDivider).

	window addMorph: self buildMorphicMessageList frame: (horizDivider @ 0 corner: 1@ secondDivider).

	self 
		addLowerPanesTo: window 
		at: (0 @ secondDivider corner: 1@1) 
		with: nil.

	initialString isEmptyOrNil ifFalse:
		[self searchString: initialString notifying: nil].
	^ window