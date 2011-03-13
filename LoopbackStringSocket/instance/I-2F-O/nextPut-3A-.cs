nextPut: aStringArray

	inArrays ifNil: [^self].

	outArrays add: aStringArray.
	"WRITESTRINGSIZES ifNil: [WRITESTRINGSIZES _ Bag new].
	aStringArray do: [ :each | WRITESTRINGSIZES add: each size]."