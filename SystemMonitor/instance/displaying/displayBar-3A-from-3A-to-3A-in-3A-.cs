displayBar: val from: min to: max in: barRect
	| break |
	break _ barRect left + (((val - min) / (max - min)) * barRect width) asInteger.
	Display fill: (barRect withRight: break) fillColor: (BarColors at: 1).
	Display fill: (barRect withLeft: break) fillColor: BarBackgroundColor.