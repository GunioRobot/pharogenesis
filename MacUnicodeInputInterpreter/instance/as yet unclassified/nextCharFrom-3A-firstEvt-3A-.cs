nextCharFrom: sensor firstEvt: evtBuf

	| keyValue |
	keyValue := evtBuf third.
	keyValue < 256 ifTrue: [^ (Character value: keyValue) squeakToIso].
	"Smalltalk systemLanguage charsetClass charFromUnicode: keyValue."
	^ Unicode value: keyValue.

