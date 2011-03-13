atRandom: aGenerator
	"Return a random element of myself.  Uses the instance of class Random supplied by the caller.  Caller should keep the generator in a variable and use the same one every time.  Use this instead of atRandom for better uniformity of random numbers because only you use the generator.  Causes an error if self has no elements."

	| index |
	index _ (aGenerator next * self size) asInteger + 1.
	^ self at: index

"	| aGen |
	aGen _ Random new.   
	(1 to: 10) atRandom: aGen
  
"