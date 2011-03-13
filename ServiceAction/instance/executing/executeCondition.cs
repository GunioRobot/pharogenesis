executeCondition
	^ [condition clone valueWithRequestor: World topRequestor]
		on: Error
		do: [false]