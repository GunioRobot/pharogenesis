initialize
	" Set a reasonable Park-Miller starting seed "
	seed := Time millisecondClockValue.

	a := 16r000041A7 asFloat.    " magic constant =      16807 "
	m := 16r7FFFFFFF asFloat.    " magic constant = 2147483647 "
	q := (m quo: a) asFloat.
	r  := (m \\ a) asFloat.