booleanTiles
	| list rcvr op arg |
	list _ #(
		(0 < 1)
		(0 <= 1)
		(0 = 1)
		(0 ~= 1)
		(0 > 1)
		(0 >= 1)).

	list _ list asOrderedCollection collect: [:entry |
		rcvr _ entry first.
		op _ (entry at: 2) asSymbol.
		arg _ entry last.
		self phraseForReceiver: rcvr op: op arg: arg resultType: #boolean].
	list add: (self phraseForReceiver: Color red op: #= arg: Color red resultType: #boolean).
	^ list "copyWith: CompoundTileMorph new"