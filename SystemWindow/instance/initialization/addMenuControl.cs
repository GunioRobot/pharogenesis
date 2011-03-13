addMenuControl
	"If I have a label area, add a menu control to it."
	| frame |
	labelArea
		ifNil: [^ self].
	"No menu if no label area"
	menuBox
		ifNotNil: [menuBox delete].
	menuBox := self createMenuBox.
	frame := LayoutFrame new.
	frame leftFraction: 0;
		 leftOffset: closeBox right + 3;
		 topFraction: 0;
		 topOffset: 0.
	menuBox layoutFrame: frame.
	labelArea addMorphBack: menuBox