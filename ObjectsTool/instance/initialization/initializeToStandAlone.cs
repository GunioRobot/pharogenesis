initializeToStandAlone
	"Initialize the receiver so that it can live as a stand-alone morph"
	| buttonPane aBin aColor heights tabsPane |
	self basicInitialize.

	self layoutInset: 6;
		layoutPolicy: ProportionalLayout new;
		useRoundedCorners;
		hResizing: #rigid;
		vResizing: #rigid;
		extent: (self minimumWidth @ self minimumHeight).

	"mode buttons"
	buttonPane := self paneForTabs: self modeTabs.
	buttonPane
		vResizing: #shrinkWrap;
		setNameTo: 'ButtonPane';
		addMorphFront: self dismissButton;
		addMorphBack: self helpButton;
		color: (aColor := buttonPane color) darker;
		layoutInset: 6;
		wrapDirection: nil;
		width: self width;
		layoutChanged; fullBounds.

	"Place holder for a tabs or text pane"
	tabsPane := Morph new
		setNameTo: 'TabPane';
		hResizing: #spaceFill;
		yourself.

	heights := { buttonPane height. 40 }.

	buttonPane vResizing: #spaceFill.
	self
		addMorph: buttonPane
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 0)
				offsets: (0 @ 0 corner: 0 @ heights first)).

	self
		addMorph: tabsPane
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 0)
				offsets: (0 @ heights first corner: 0 @ (heights first + heights second))).

	aBin := (PartsBin newPartsBinWithOrientation: #leftToRight from: #())
		listDirection: #leftToRight;
		wrapDirection: #topToBottom;
		color: aColor lighter lighter;
		setNameTo: 'Parts';
		dropEnabled: false;
		vResizing: #spaceFill;
		yourself.

	self
		addMorph: aBin
		fullFrame: (LayoutFrame
				fractions: (0 @ 0 corner: 1 @ 1)
				offsets: (0 @ (heights first + heights second) corner: 0 @ 0)).

	self color: (Color r: 0.0 g: 0.839 b: 0.226);
		setNameTo: 'Objects' translated;
		showCategories.
