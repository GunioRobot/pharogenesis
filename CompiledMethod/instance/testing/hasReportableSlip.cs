hasReportableSlip
	"Answer whether the receiver contains anything that should be brought to the attention of the author when filing out.   Customize the lists here to suit your preferences.  If slips do not get reported in spite of your best efforts here, make certain that the Preference 'checkForSlips' is set to true."

	| assoc | 
	#(doOnlyOnce: halt halt: hottest printDirectlyToDisplay toRemove personal urgent) do:
		[:aLit | (self hasLiteral: aLit) ifTrue: [^ true]].

	#(Transcript AA BB CC DD EE) do:
		[:aSymbol | (assoc _ (Smalltalk associationAt: aSymbol ifAbsent: [nil])) ifNotNil:
			[(self hasLiteral: assoc) ifTrue: [^ true]]].

	^ false