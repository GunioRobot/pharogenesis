testFromDateAndTime

	| oc1 oc2 |
	oc1 _ OrderedCollection new.
	DateAndTime today to: DateAndTime tomorrow by: 10 hours do: [ :dt | oc1 add: dt ].

	oc2 _ { DateAndTime today. 
			(DateAndTime today + 10 hours). 
				(DateAndTime today + 20 hours) }.

	self assert: (oc1 asArray = oc2)