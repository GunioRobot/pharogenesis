testPlayWithMe1Romoval
	"A trivial test for checking that PlayWithMe classes are all removed"
	self deny: ( Smalltalk hasClassNamed: 'PlayWithMe1' ) .