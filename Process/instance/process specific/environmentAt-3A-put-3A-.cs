environmentAt: key put: value
	env ifNil: [ env := Dictionary new ]. 
	^ env at: key put: value.