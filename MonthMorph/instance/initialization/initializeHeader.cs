initializeHeader
	| title sep frame button monthName |
	title := (self findA: WeekMorph) title.
	title hResizing: #spaceFill.
	"should be done by WeekMorph but isn't"
	title submorphsDo: [:m | m hResizing: #spaceFill].
	monthName := month name.
	self width < 160 
		ifTrue: 
			[monthName := (#(6 7 9) includes: month index) 
				ifTrue: [monthName copyFrom: 1 to: 4]
				ifFalse: [monthName copyFrom: 1 to: 3]].
	sep := (Morph new)
				color: Color transparent;
				extent: title width @ 1.
	self
		addMorph: sep;
		addMorph: title;
		addMorph: sep copy.
	button := (SimpleButtonMorph new)
				target: self;
				actWhen: #whilePressed;
				color: (Color 
							r: 0.8
							g: 0.8
							b: 0.8).
	frame := (AlignmentMorph new)
				color: Color transparent;
				listDirection: #leftToRight;
				hResizing: #spaceFill;
				vResizing: #shrinkWrap;
				layoutInset: 0.
	frame
		addMorph: (button
					label: '>>';
					actionSelector: #nextYear;
					width: 15);
		addMorph: ((button copy)
					label: '>';
					actionSelector: #next;
					width: 15);
		addMorph: (((AlignmentMorph new)
					color: Color transparent;
					listDirection: #topToBottom;
					wrapCentering: #center;
					cellPositioning: #topCenter;
					extent: (title fullBounds width - (button width * 3)) @ title height) 
						addMorph: (StringMorph new 
								contents: monthName , ' ' , month year printString));
		addMorph: ((button copy)
					label: '<';
					actionSelector: #previous;
					width: 15);
		addMorph: ((button copy)
					label: '<<';
					actionSelector: #previousYear;
					width: 15).
	"hResizing: #shrinkWrap;"
	self addMorph: frame