nameForViewer
	"Answer a name to be shown in a Viewer that is viewing the receiver"

	| aName |
	(aName := self knownName) ifNotNil: [^ aName].

	^ [(self asString copyWithout: Character cr) truncateTo:  27] ifError:
		[:msg :rcvr | ^ self class name printString]