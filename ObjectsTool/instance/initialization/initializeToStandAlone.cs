initializeToStandAlone
	"Initialize the receiver so that it can live as a stand-alone morph"
	| buttonPane aBin aColor heights tabsPane |
	self basicInitialize.

	self layoutInset: 0;
		layoutPolicy: ProportionalLayout new;
		useRoundedCorners;
		hResizing: #rigid;
		vResizing: #rigid;
		extent: (self minimumWidth @ self minimumHeight).

	"mode buttons"
	buttonPane := self paneForTabs: self modeTabs.
	buttonPane color: ColorTheme current dialogColor.
	buttonPane
		vResizing: #shrinkWrap;
		setNameTo: 'ButtonPane';
		addMorphFront: self dismissButton;
		addMorphBack: self helpButton;
		color: (aColor := buttonPane color) darker;
		layoutInset: 5;
		wrapDirection: nil;
		width: self width;
		layoutChanged; fullBounds.

	"Place holder for a tabs or text pane"
	tabsPane := Morph new.
	tabsPane
		color: ColorTheme current dialogColor;
		setNameTo: 'TabPane';
		hResizing: #spaceFill.

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

	self
		borderWidth: ColorTheme current dialogBorderWidth;
		borderColor: ColorTheme current dialogBorderColor;
		color: ColorTheme current dialogColor;
		setNameTo: 'Objects' translated;
		showCategories.
