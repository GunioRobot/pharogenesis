signal
	"Signal the occurrence of an exceptional condition."

	| ex |
	ex := self new.
	ex initialContext: thisContext sender.
	^ex signal