initializeWeeks
	| weeks |
	self removeAllMorphs.
	weeks _ OrderedCollection new.
	month weeksDo:
		[ :w |
		weeks add: (WeekMorph newWeek: w month: month tileRect: tileRect model: model)].

	weeks reverseDo: 
		[ :w | 
		w hResizing: #spaceFill; vResizing: #spaceFill.
		"should be done by WeekMorph but isn't"
		w submorphsDo:[ :m | m hResizing: #spaceFill; vResizing: #spaceFill ].
		self addMorph: w ].

	self 
		initializeHeader;
		highlightToday.

