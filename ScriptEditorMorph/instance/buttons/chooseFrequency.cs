chooseFrequency
	| currentFrequency aMenu |
	currentFrequency _ self scriptInstantiation frequency.
	currentFrequency = 0 ifTrue: [currentFrequency _ 1].
	aMenu _ MenuMorph new defaultTarget: self.
	#(1 2 5 10 25 50 100 1000 5000 10000) do:
		[:i | aMenu add: i printString selector: #setFrequencyTo: argument: i].
	
	aMenu add: 'other...' translated action: #typeInFrequency.
	aMenu addTitle: ('Choose frequency (current: {1})' translated format: {currentFrequency}).
	aMenu  popUpEvent: self currentEvent in: self world