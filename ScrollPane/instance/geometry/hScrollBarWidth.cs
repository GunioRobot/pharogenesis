hScrollBarWidth
"Return the width of the horizontal scrollbar"


	| w |
	
	w _ bounds width - (2 * borderWidth).
	
	(retractableScrollBar not and: [self vIsScrollbarNeeded])
		ifTrue: [w _ w - self scrollBarThickness ].
		
	^w 
