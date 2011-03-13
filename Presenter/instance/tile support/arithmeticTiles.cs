arithmeticTiles
	| list rcvr op arg |
		list _ #(
		(1 + 1)
		(1 - 1)
		(2 * 2)
		(6 / 2)
		(4 max: 3)
		(7 min: 2)).

	^ list collect: [:entry |
		rcvr _ entry first.
		op _ (entry at: 2) asSymbol.
		arg _ entry last.
		self phraseForReceiver: rcvr op: op arg: arg resultType: #number]