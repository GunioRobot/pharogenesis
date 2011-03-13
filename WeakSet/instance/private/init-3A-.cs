init: n
	"Initialize array to an array size of n"

	flag _ Object new.
	array _ WeakArray new: n.
	array atAllPut: flag.
	tally _ 0