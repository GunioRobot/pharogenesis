init: n
	super init: n.
	hashBlock _ [:element| element hash].
	equalBlock _ [:element1 :element2| element1 = element2]