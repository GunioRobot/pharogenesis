beRootIfOld: oop
	"Record that the given oop in the old object area may point to an object in the young area."

	| header |
	self inline: false.
	((oop < youngStart) and: [(self isIntegerObject: oop) not]) ifTrue: [
		"oop is in the old object area"
		header _ self longAt: oop.
		(header bitAnd: RootBit) = 0 ifTrue: [
			"record oop as root only if not already recorded"
			rootTableCount < RootTableSize ifTrue: [
				"record root only if there is room in the roots table"
				rootTableCount _ rootTableCount + 1.
				rootTable at: rootTableCount put: oop.
				self longAt: oop put: (header bitOr: RootBit).
			].
		].
	].