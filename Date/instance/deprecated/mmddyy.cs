mmddyy
	"Please use mmddyyyy instead, so dates in 2000 will be unambiguous"

	^ self 
		deprecated: 'Use #mmddyyyy';
		printFormat: #(2 1 3 $/ 1 2)
