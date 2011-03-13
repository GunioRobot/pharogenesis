unwindTo: aContext

	| ctx unwindBlock |
	ctx := self.
	[(ctx := ctx findNextUnwindContextUpTo: aContext) isNil] whileFalse: [
		unwindBlock := ctx tempAt: 1.
		unwindBlock == nil ifFalse: [
			ctx tempAt: 1 put: nil.
			unwindBlock value]
	].
