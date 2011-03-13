partsBinString
	"Answer the string to be shown in a menu to represent the parts-bin status"

	^ referent isPartsBin
		ifTrue:	['<yes>parts-bin']
		ifFalse:	['<no>parts-bin']