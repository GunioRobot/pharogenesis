validateRoots 
	"Verify that every old object that points to a new object 
		has its root bit set, and
		appears in the rootTable.
	This method should not be called if the rootTable is full, because roots
	are no longer recorded, and incremental collections are not attempted.
	If DoAssertionChecks is true, this routine will halt on an unmarked root.
	Otherwise, this routine will merely return true in that case."
	| oop fieldAddr fieldOop header badRoot |
	badRoot _ false.
	oop _ self firstObject.

	[oop < youngStart] whileTrue:
		[(self isFreeObject: oop) ifFalse:
			[fieldAddr _ oop + (self lastPointerOf: oop).
			[fieldAddr > oop] whileTrue:
				[fieldOop _ self longAt: fieldAddr.
				(fieldOop >= youngStart and: [(self isIntegerObject: fieldOop) not]) ifTrue:
					["fieldOop is a pointer to a young object"
					header _ self longAt: oop.
					(header bitAnd: RootBit) = 0
					ifTrue:
						["Forbidden: points to young obj but root bit not set."
						DoAssertionChecks ifTrue: [self error: 'root bit not set'].
						badRoot _ true]
					ifFalse:
						["Root bit is set"
						"Extreme test -- validate that oop was entered in rootTable too..."
						"Disabled for now...
						found _ false.
						1 to: rootTableCount do:
							[:i | oop = (rootTable at: i) ifTrue: [found _ true]].
						found ifFalse:
							[DoAssertionChecks ifTrue: [self error: 'root table not set'].
							badRoot _ true].
						..."
						]].
				fieldAddr _ fieldAddr - 4]].
		oop _ self objectAfter: oop].
	^ badRoot