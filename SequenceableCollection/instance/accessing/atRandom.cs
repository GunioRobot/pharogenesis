atRandom
	"Return a random element of myself.  Uses a shared random number generator owned by class Collection.  If you use this a lot, define your own instance of Random and use atRandom:.  Causes an error if self has no elements."

	| index |
	index _ (RandomForPicking next * self size) asInteger + 1.
	^ self at: index

"  #('one' 'or' 'the' 'other') atRandom
   (1 to: 10) atRandom
   'Just pick one of these letters at random' atRandom
"