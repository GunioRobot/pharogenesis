possibleRootStoreInto: oop value: valueObj
	"Called when storing the given value object into the given old object. If valueObj is young, record the fact that oldObj is now a root for incremental garbage collection."
	"Warning: No young objects should be recorded as roots."

	| header |
	self inline: false.
	((valueObj >= youngStart) and:
	 [(self isIntegerObject: valueObj) not]) ifTrue: [
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