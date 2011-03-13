initializeHeader
	| title sep  frame button monthName |
	title _ (self findA: WeekMorph) title.
	title hResizing: #spaceFill.
	"should be done by WeekMorph but isn't"
	title submorphsDo:[:m| m hResizing: #spaceFill].
	monthName _ month name.
	self width < 160 ifTrue:
		[(#(6 7 9) includes: month index)
			ifTrue: [monthName _ monthName copyFrom: 1 to: 4]
			ifFalse: [monthName _ monthName copyFrom: 1 to: 3]].
	sep _ Morph new color: Color transparent; extent: title width @ 1.
	self
		addMorph: sep;
		addMorph: title;
		addMorph: sep copy.
	button _ SimpleButtonMorph new
				target: self;
				actWhen: #whilePressed;
				color: (Color r: 0.8 g: 0.8 b: 0.8).
	frame _ AlignmentMorph new
		color: Color transparent;
		listDirection: #leftToRight;
		hResizing: #spaceFill;
		vResizing: #shrinkWrap;
		layoutInset: 0.
	frame
		addMorph:
			(button
				label: '>>';
				actionSelector: #nextYear;
				width: 15);
		addMorph:
			(button copy
				label: '>';
				actionSelector: #next;
				width: 15);
		addMorph:
			((AlignmentMorph new
				color: Color transparent;
				listDirection: #topToBottom;
				"hResizing: #shrinkWrap;"
				wrapCentering: #center; cellPositioning: #topCenter;
				extent: (title fullBounds width - (button width * 3)) @ title height)
				addMorph:
					(StringMorph new
						contents:
							monthName, ' ', month year printString));
		addMorph:
			(button copy
				label: '<';
				actionSelector: #previous;
				width: 15);
		addMorph:
			(button copy
				label: '<<';
				actionSelector: #previousYear;
				width: 15).
	self addMorph: frame