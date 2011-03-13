displayLine: line offset: baseOffset leftInRun: leftInRun
	| drawFont offset aText string s doJustified |

	self setTextStylesForOffset: ((line first) + 1).	" sets up various instance vars from text styles "
	drawFont _ self font.
	offset _ baseOffset.
	offset _ offset + (line left @ (line top + line baseline - drawFont ascent )). 
	offset _ offset + ((self textStyle alignment caseOf:{
		[2] -> [ line paddingWidth /2 ].
		[1] -> [ line paddingWidth ] } otherwise:[0]) @ 0).

	canvas moveto: offset.

	aText _ paragraph text copyFrom: line first to: line last.
	doJustified _ (paragraph textStyle alignment = 3)
						and: [ (paragraph text at:line last) ~= Character cr
						and: [aText runs runs size = 1]].
	string _ aText string.
	aText runs withStartStopAndValueDo: [:start :stop :attributes |
		self setTextStylesForOffset: (start + line first - 1).	" sets up inst vars from text styles "
		s _ string copyFrom: start to: stop.
		drawFont _ self font.
		canvas setFont: drawFont.
		canvas 
			textStyled: s
			at: offset 		"<--now ignored"
			font: drawFont 		"<--now ignored"
			color: foregroundColor
			justified: doJustified		"<-can't do this now for multi-styles" 
			parwidth: line right - line left.
	].
