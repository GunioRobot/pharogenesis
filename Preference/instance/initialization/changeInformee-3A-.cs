changeInformee: informee
	"Set the object to be informed when my value changes"

	changeInformee := (informee == nil or: [informee == #nil])
						ifTrue: [nil]
						ifFalse:	[(informee isKindOf: Symbol)
							ifTrue:
								[Smalltalk at: informee]
							ifFalse:
								[informee]]