readDataFrom: aDataStream size: anInteger
	"Symbols have new hash in this world.  "

	| aSet |
	aSet _ super readDataFrom: aDataStream size: anInteger.
	aSet rehash.
	^ aSet
