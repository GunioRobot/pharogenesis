responseCheck
	"If data is waiting, do a responseOK to catch any error reports."

	self dataAvailable ifTrue: [^ self responseOK].
	^ true	"all OK so far"