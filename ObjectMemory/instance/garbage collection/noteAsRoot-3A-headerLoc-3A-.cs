noteAsRoot: oop headerLoc: headerLoc 
	"Record that the given oop in the old object area points to an 
	object in the young area. 
	HeaderLoc is usually = oop, but may be an addr in a 
	forwarding block."
	| header |
	self inline: true.
	header _ self longAt: headerLoc.
	(header bitAnd: RootBit) = 0
		ifTrue: ["record oop as root only if not already recorded"
			rootTableCount < RootTableRedZone
				ifTrue: ["record root if there is enough room in the roots 
					table "
					rootTableCount _ rootTableCount + 1.
					rootTable at: rootTableCount put: oop.
					self longAt: headerLoc put: (header bitOr: RootBit)]
				ifFalse: ["we're getting in the red zone"
					rootTableCount < RootTableSize
						ifTrue: ["but there's still space to record it"
							rootTableCount _ rootTableCount + 1.
							rootTable at: rootTableCount put: oop.
							self longAt: headerLoc put: (header bitOr: RootBit).
							"but force an IGC on the next allocation"
							allocationCount _ allocationsBetweenGCs + 1]]]