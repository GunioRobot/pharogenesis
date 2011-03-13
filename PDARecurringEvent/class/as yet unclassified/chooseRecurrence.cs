chooseRecurrence

	^ (CustomMenu selections: self basicNew validRecurrenceSymbols) startUp
		ifNil: [#dateOfYear]