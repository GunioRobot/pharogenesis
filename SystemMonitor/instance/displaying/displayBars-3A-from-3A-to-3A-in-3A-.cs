displayBars: vals from: min to: max in: barRect
	| break prevBreak |
	prevBreak _ barRect left.
	vals doWithIndex: [:val :index |
		break _ barRect left + (((val - min) / (max - min)) * barRect width) asInteger.
		Display fill: ((barRect withLeft: prevBreak) withRight: break) fillColor: (BarColors at: index).
		prevBreak _ break].
	Display fill: (barRect withLeft: prevBreak) fillColor: BarBackgroundColor.