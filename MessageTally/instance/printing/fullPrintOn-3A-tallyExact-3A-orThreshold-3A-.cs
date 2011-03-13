fullPrintOn: aStream tallyExact: isExact orThreshold: perCent
	| threshold |  
	isExact ifFalse: [threshold _ (perCent asFloat / 100 * tally) rounded].
	aStream nextPutAll: '**Tree**'; cr.
	self treePrintOn: aStream
		tabs: OrderedCollection new
		thisTab: ''
		total: tally
		tallyExact: isExact
		orThreshold: threshold.
	aStream nextPut: Character newPage; cr.
	aStream nextPutAll: '**Leaves**'; cr.
	self leavesPrintOn: aStream
		tallyExact: isExact
		orThreshold: threshold