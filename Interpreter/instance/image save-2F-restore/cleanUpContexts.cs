cleanUpContexts
	"Sweep memory, nilling out all fields of contexts above the stack pointer."
	| oop header fmt sz |
	oop _ self firstObject.
	[oop < endOfMemory] whileTrue: [
		(self isFreeObject: oop) ifFalse: [
			header _ self longAt: oop.
			fmt _ (header >> 8) bitAnd: 16rF.
			(fmt = 3 and: [self isContextHeader: header]) ifTrue:
				[sz _ self sizeBitsOf: oop.
				(self lastPointerOf: oop) + 4 to: sz - BaseHeaderSize by: 4
					do: [:i | self longAt: oop+i put: nilObj]]].
		oop _ self objectAfter: oop.
	].
