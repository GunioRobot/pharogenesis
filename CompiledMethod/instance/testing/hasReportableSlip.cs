hasReportableSlip
	"Answer whether the receiver contains anything that might be brought to the attention of the author when filing out.   Customize the lists to suit your preferences.  If slips do not get reported in spite of your best efforts here, make certain that the Preference 'suppressCheckForSlips' has not been hard-coded to true."

	| assoc | 
	#(halt halt: urgent hottest) do:
		[:aLit | (self hasLiteral: aLit) ifTrue: [^ true]].

	#(Transcript AA BB CC DD EE) do:
		[:aSymbol | (assoc _ (Smalltalk associationAt: aSymbol ifAbsent: [nil])) ifNotNil:
			[(self hasLiteral: assoc) ifTrue: [^ true]]].

	^ false