withStartStopAndValueDo: aBlock
	| start stop |
	start _ 1.
	runs with: values do:
		[:len : val | stop _ start + len - 1.
		aBlock value: start value: stop value: val.
		start _ stop + 1]
		