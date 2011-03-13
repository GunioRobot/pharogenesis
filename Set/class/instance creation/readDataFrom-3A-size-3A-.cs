readDataFrom: aDataStream size: anInteger
	"Symbols have new hash in this world.  9/7/96 tk"

	| aSet |
	aSet _ super readDataFrom: aDataStream size: anInteger.
	aSet rehash.
	^ aSet
