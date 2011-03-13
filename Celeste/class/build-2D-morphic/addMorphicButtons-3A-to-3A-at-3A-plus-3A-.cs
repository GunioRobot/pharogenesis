addMorphicButtons: buttons to: row at: innerFractions plus: verticalOffset 
	| delta buttonRow |
	delta _ 25.
	buttonRow _ self morphicButtonRowFrom: buttons.
	buttonRow 
				color: (Color gray alpha: 0.2);
				 borderWidth: 1;
				 borderColor: Color lightGray.
	row addMorph: buttonRow
				fullFrame: (LayoutFrame
						fractions: innerFractions
						offsets: (0@verticalOffset corner: 0@(verticalOffset + delta))).
	^ verticalOffset + delta