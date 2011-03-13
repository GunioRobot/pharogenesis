example
	"If you just want a quick random integer, use:
		10 atRandom
	Every integer interval can give a random number:
		(6 to: 12) atRandom
	Most Collections can give randomly selected elements:
		'pick one of these letters randomly' atRandom

	The correct way to use class Random is to store one in 
	an instance or class variable:
		myGenerator _ Random new.
	Then use it every time you need another number between 0.0 and 1.0
		myGenerator next

	"