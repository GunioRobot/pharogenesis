initializeHeader
	| title sep  frame button |
	title _ (self findA: WeekMorph) title.
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
		orientation: #horizontal;
		inset: 0.
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
				orientation: #vertical;
				centering: #center;
				extent: (title fullBounds width - (button width * 3)) @ title height)
				addMorph:
					(StringMorph new
						contents:
							month name, ' ', month year printString));
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
