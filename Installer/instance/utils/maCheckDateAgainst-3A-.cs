maCheckDateAgainst: okDate

	(okDate notNil and: [date < okDate asDate ]) ifTrue: [ self notify: 'bug ', self bug asString, ' updated on ', date printString ].
 