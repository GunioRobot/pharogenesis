externalName
	"Answer an external name for the receiver.  If it has none, supply a backstop name"

	| aCostume |
	^ (aCostume _ self costume) ifNotNil: [aCostume externalName] ifNil: ['an orphaned Player']