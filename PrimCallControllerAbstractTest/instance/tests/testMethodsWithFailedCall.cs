testMethodsWithFailedCall
	| methodRefs |
	methodRefs := pcc methodsWithFailedCall.
	self assert: methodRefs size >= 1 & ((methodRefs
				select: [:mRef | mRef methodSymbol = self failedCallSelector]) size = 1)