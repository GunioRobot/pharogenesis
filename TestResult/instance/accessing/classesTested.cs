classesTested
	^ (self tests collect: [ :testCase | testCase class ]) asSet