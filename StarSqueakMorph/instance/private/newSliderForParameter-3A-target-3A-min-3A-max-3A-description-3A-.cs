newSliderForParameter: parameter target: target min: min max: max description: description

	| c slider r s |
	c := (AlignmentMorph newColumn)
		color: Color lightBlue;
		borderWidth: 2;
		hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		useRoundedCorners.
	slider := SimpleSliderMorph new
		color: (Color r: 0.065 g: 0.548 b: 0.645);
		extent: 150@2;
		target: target;
		actionSelector: (parameter, ':') asSymbol;
		minVal: min;
		maxVal: max;
		adjustToValue: (target perform: parameter asSymbol).
	c addMorphBack: slider.
	r := (AlignmentMorph newRow)
		color: Color lightBlue;
		hResizing: #spaceFill;
		vResizing: #spaceFill.
	s := StringMorph new contents: parameter, ': '.
	r addMorphBack: s.
	s := UpdatingStringMorph new
		target: target;
		getSelector: parameter asSymbol;
		putSelector: (parameter, ':') asSymbol;
		floatPrecision: (10.0 raisedTo: (((max - min) / 150.0) log: 10) floor);
		step.
	r addMorphBack: s.
	c addMorphBack: r.
	c setBalloonText: description.
	^ c
