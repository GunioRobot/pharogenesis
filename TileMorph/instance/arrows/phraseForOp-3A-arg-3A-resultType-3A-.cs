phraseForOp: op arg: arg resultType: resultType
	"Answer a numeric-valued phrase derived from the receiver, whose extension arrow has just been hit.  Pass along my float-precision."

	| phrase srcLabel distLabel |
	phrase _ self presenter
				phraseForReceiver: literal
				op: op
				arg: 1
				resultType: #Number.
	srcLabel _ self findA: UpdatingStringMorph.
	distLabel _ phrase submorphs first submorphs first findA: UpdatingStringMorph.
	distLabel floatPrecision: srcLabel floatPrecision.
	^ phrase