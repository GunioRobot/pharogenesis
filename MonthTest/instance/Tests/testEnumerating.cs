testEnumerating
	| weeks |
	weeks := OrderedCollection new.
	month eachWeekDo: [:w | weeks add: w firstDate].
	0 to: 4
		do: 
			[:i | 
			weeks 
				remove: (Week starting:  ('29 June 1998' asDate addDays: i * 7)) firstDate].
	self assert: weeks isEmpty