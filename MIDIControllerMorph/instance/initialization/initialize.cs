initialize

	| slider |
	super initialize.
	orientation _ #vertical.
	centering _ #center.
	hResizing _ vResizing _ #shrinkWrap.
	self color: (Color r: 0.484 g: 0.613 b: 0.0).
	self borderWidth: 1.
	channel _ 0.
	controller _ 7.  "channel volume"

	slider _ SimpleSliderMorph new
		target: self;
		actionSelector: #newSliderValue:;
		minVal: 0;
		maxVal: 127;
		extent: 128@10.
	self addMorphBack: slider.
	self addMorphBack: (StringMorph contents: 'Midi Controller').
	self updateLabel.
