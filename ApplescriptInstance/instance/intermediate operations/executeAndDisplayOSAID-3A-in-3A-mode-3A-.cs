executeAndDisplayOSAID: anOSAID in: contextOSAID mode: anInteger

	| resultOSAID resultAEDesc |
	resultOSAID _ (self executeOSAID: anOSAID in: contextOSAID mode: anInteger)
		ifNil: [^nil].
	resultAEDesc _ (self displayAndDisposeOSAID: resultOSAID as: 'TEXT' mode: anInteger)
		ifNil: [^nil].
	^resultAEDesc asStringThenDispose
  