readHeaderPAM
	"read pam header, not tested"
	| loop line tokens key val |
	tupleType _ ''.
	loop _ true.
	loop whileTrue:[
		line _ self pbmGetLine.
		tokens _ line findTokens: ' '.
		tokens size = 2 ifTrue:[
			key _ tokens at: 1 asUppercase.
			val _ tokens at: 2.
			key caseOf: {
				['WIDTH'] 		-> [cols _ val asInteger].
				['HEIGHT'] 		-> [rows _ val asInteger].
				['DEPTH'] 		-> [depth _ val asInteger].
				['MAXVAL']		-> [maxValue _ val asInteger].
				['TUPLETYPE']	-> [tupleType _ tupleType, ' ', val].
				['ENDHDR']		-> [loop _ false].
			}
		]
	].
	Transcript cr; show: 'PAM file class ', type asString, ' size ', cols asString, ' x ', 
		rows asString, ' maxValue =', maxValue asString, ' depth=', depth asString.
