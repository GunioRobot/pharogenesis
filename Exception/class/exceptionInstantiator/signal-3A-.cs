signal: signalerText
	"TFEI - Signal the occurrence of an exceptional condition with a specified textual description."

	| ex |
	ex := self new.
	ex initialContext: thisContext sender.
	^ex signal: signalerText