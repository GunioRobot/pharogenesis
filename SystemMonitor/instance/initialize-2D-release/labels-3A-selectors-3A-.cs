labels: labelArray selectors: selectorArray

	| labelHeight labelWidth topLeft bottomRight |
	self readVMParameters.
	minValues _ selectorArray collect: [:str | self perform: (str , 'Min') asSymbol].
	maxValues _ selectorArray collect: [:str | self perform: (str , 'Max') asSymbol].
	valSelectors _ selectorArray collect: [:str | (str , 'Val') asSymbol].

	labels _ labelArray collect: [:str |
		(DisplayText text: str asText)
			foregroundColor: ForegroundColor
			backgroundColor: BackgroundColor].

	baselineSkip _ (labels at: 1) height.
	baselineSkip = 0
		ifTrue:	"empty lables: use a completely undecorated display, flush-bottom/left"
			[baselineSkip _ DefaultBarHeight.
			labelHeight _ baselineSkip * labels size.
			topLeft _ 0@(Display height - labelHeight + BarBorderWidth).
			bottomRight _ BarWidth@(Display height).
			window _ topLeft corner: bottomRight]
		ifFalse:
			[labelHeight _ baselineSkip * labels size.
			labelWidth _ (labels inject: 0 into: [:max :lbl | max max: lbl width]) + (Inset * 2) + BarBorderWidth.
			topLeft _ 0@(Display height - labelHeight - (Inset * 2)).
			bottomRight _ (labelWidth + (2*Inset) + BarWidth)@(Display height).
			window _ (topLeft corner: bottomRight) insetBy: Inset.
			"window _ window translateBy: (BorderWidth negated)@BorderWidth."
			self displayBordersAndLabels]