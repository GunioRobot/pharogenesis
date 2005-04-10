nextCharFrom: sensor firstEvt: evtBuf

	| keyValue |
	keyValue := evtBuf third.
	keyValue < 256 ifTrue: [^ (Character value: keyValue) macToSqueak].
	"Smalltalk systemLanguage charsetClass charFromUnicode: keyValue."
	^ Unicode value: keyValue.

