nextPut: aStringArray

	inArrays ifNil: [^self].

	outArrays add: aStringArray.
	"WRITESTRINGSIZES ifNil: [WRITESTRINGSIZES := Bag new].
	aStringArray do: [ :each | WRITESTRINGSIZES add: each size]."