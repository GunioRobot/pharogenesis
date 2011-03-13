openMonthView
	| row month col paneExtent window paneColor nRows |
	month _ date notNil
		ifTrue: [date month]
		ifFalse: ["But... it's here somewhere..."
				((self dependents detect: [:m | m isKindOf: PDAMorph])
					findA: MonthMorph) month].
	window _ SystemWindow labelled: month printString.
	paneColor _ Color transparent.
	window color: (Color r: 0.968 g: 1.0 b: 0.355).
	nRows _ 0.  month eachWeekDo: [:w | nRows _ nRows + 1].
	paneExtent _ ((1.0/7) @ (1.0/nRows)).
	row _ 0.
	month eachWeekDo:
		[:week | col _ 0.
		week do:
			[:day | day month = month ifTrue:
				[window addMorph: ((PluggableListMorph on: self list: nil
						selected: nil changeSelected: nil menu: nil keystroke: nil)
							list: {(day dayOfMonth printString , '  ' , day weekday) asText allBold}
								, (self scheduleListForDay: day))
					frame: (paneExtent * (col@row) extent: paneExtent)].
			col _ col + 1].
		row _ row + 1].

	window firstSubmorph color: paneColor.
	window updatePaneColors.
	window openInWorld