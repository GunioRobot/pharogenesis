verbosePrimesUpTo: max do: aBlock
	"Integer verbosePrimesUpTo: SmallInteger maxVal" "<- heh, heh"
	"Compute primes up to max, but be verbose about it"
	| lastTime nowTime |
	lastTime _ Time millisecondClockValue.
	Utilities informUserDuring:[:bar|
		bar value:'Computing primes...'.
		self primesUpTo: max do:[:prime|
			aBlock value: prime.
			nowTime _ Time millisecondClockValue.
			(nowTime - lastTime > 1000) ifTrue:[
				lastTime _ nowTime.
				bar value:'Last prime found: ', prime printString]]].