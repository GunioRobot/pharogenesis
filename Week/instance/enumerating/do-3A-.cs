do: aBlock
	| date |
	date _ self asDate.
	7 timesRepeat:
		[aBlock value: date.
		date _ date addDays: 1]