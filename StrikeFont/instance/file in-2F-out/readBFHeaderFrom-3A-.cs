readBFHeaderFrom: f
	name _ self restOfLine: 'Font name = ' from: f.
	ascent _ (self restOfLine: 'Ascent = ' from: f) asNumber.
	descent _ (self restOfLine: 'Descent = ' from: f) asNumber.
	maxWidth _ (self restOfLine: 'Maximum width = ' from: f) asNumber.
	pointSize _ (self restOfLine: 'Font size = ' from: f) asNumber.
	name _ (name copyWithout: Character space) ,
				(pointSize < 10
					ifTrue: ['0' , pointSize printString]
					ifFalse: [pointSize printString]).
	minAscii _ 258.
	maxAscii _ 0.
	superscript _ ascent - descent // 3.	
	subscript _ descent - ascent // 3.	
	emphasis _ 0.
	type _ 0.  "ignored for now"
