translatedWordingFor: aSymbol
	"If I have a translated wording for aSymbol, return it, else return aSymbol.  Caveat: at present, this mechanism is only germane for *assignment-operator wordings*"

	#(: Incr: Decr: Mult:) with: #('' 'increase by' 'decrease by' 'multiply by') do:
		[:a :b | aSymbol == a ifTrue: [^ b translated]].

	^ aSymbol translated