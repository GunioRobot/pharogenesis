showTongue
	| tongue |
	self hideTongue.
	tongue := CurveMorph vertices: {10@2. 21@5. 16@23. 10@27. 5@23. 2@4} color: Color red borderWidth: 0 borderColor: Color black.
	tongue position: self center - (10 @ 0).
	self addMorphFront: tongue