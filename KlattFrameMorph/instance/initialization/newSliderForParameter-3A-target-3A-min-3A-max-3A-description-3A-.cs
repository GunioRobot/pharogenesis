newSliderForParameter: parameter target: target min: min max: max description: description
	| r slider m |
	r _ AlignmentMorph newRow.
	r color: self color; borderWidth: 0; layoutInset: 0.
	r hResizing: #spaceFill; vResizing: #shrinkWrap; extent: 5@20; wrapCentering: #center; cellPositioning: #leftCenter; cellInset: 4@0.

	slider _ SimpleSliderMorph new
		color: (Color r: 0.065 g: 0.548 b: 0.645);
		extent: 120@2;
		target: target;
		actionSelector: (parameter, ':') asSymbol;
		minVal: min;
		maxVal: max;
		adjustToValue: (target perform: parameter asSymbol).
	r addMorphBack: slider.

	m _ StringMorph new contents: parameter, ': '; hResizing: #rigid.
	r addMorphBack: m.
	m _ UpdatingStringMorph new
		target: target; getSelector: parameter asSymbol; putSelector: (parameter, ':') asSymbol;
		width: 60; growable: false; floatPrecision: (max - min / 100.0 min: 1.0); vResizing: #spaceFill; step.
	r addMorphBack: m.
	r setBalloonText: description.
	^ r