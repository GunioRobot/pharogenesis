isStoredProblems: cls sel: selector meta: aBoolean
	"self new isKnowProblem: PNMReaderWriter sel: #nextImage"
	
	^ self decompilerDiscrepancies includes: {cls name asSymbol. selector . aBoolean}