unwindTo: aContext

	| ctx unwindBlock |
	ctx := self.
	[(ctx _ ctx findNextUnwindContextUpTo: aContext) isNil] whileFalse: [
		unwindBlock := ctx tempAt: 1.
		unwindBlock == nil ifFalse: [
			ctx tempAt: 1 put: nil.
			unwindBlock value]
	].
