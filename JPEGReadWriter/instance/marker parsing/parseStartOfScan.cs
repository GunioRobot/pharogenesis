parseStartOfScan

	| length n id value dcNum acNum comp |
	length _ self nextWord.
	n _ self next.
	(length ~= (n*2 + 6)) | (n < 1) ifTrue: [self error: 'SOS length is incorrect'].
	currentComponents _ Array new: n.
	1 to: n do: [:i |
		id _ self next.
		value _ self next.
		dcNum _ (value >> 4) bitAnd: 16r0F.
		acNum _ value bitAnd: 16r0F.
		comp _ components detect: [:c | c id = id].
		comp
			dcTableIndex: dcNum+1;
			acTableIndex: acNum+1.
		currentComponents at: i put: comp].
	ss _ self next.
	se _ self next.
	value _ self next.
	ah _ (value >> 4) bitAnd: 16r0F.
	al _ value bitAnd: 16r0F.
	self initialSOSSetup.
	self perScanSetup.
	sosSeen _ true