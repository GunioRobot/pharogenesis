fromRemoteCanvasEncoding: encoded
	"DisplayTransform fromRemoteCanvasEncoding:  'Matrix,1065353216,0,1137541120,0,1065353216,1131610112,'"
	| nums transform encodedNums |
	"split the numbers up"
	encodedNums _ encoded findTokens: ','.

	"remove the initial 'Matrix' specification"
	encodedNums _ encodedNums asOrderedCollection.
	encodedNums removeFirst.

	"parse the numbers"
	nums _ encodedNums collect: [ :enum |
		Integer readFromString: enum ].

	"create an instance"
	transform _ self new.

	"plug in the numbers"
	nums doWithIndex: [ :num :i |
		transform basicAt: i put: num ].

	^transform