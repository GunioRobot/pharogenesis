restart
	"Unwind thisContext to self and resume from beginning.  Execute unwind blocks when unwinding.  ASSUMES self is a sender of thisContext"

	| ctxt unwindBlock |
	self isDead ifTrue: [self cannotReturn: nil to: self].
	self privRefresh.
	ctxt _ thisContext.
	[	ctxt _ ctxt findNextUnwindContextUpTo: self.
		ctxt isNil
	] whileFalse: [
		unwindBlock _ ctxt tempAt: 1.
		unwindBlock ifNotNil: [
			ctxt tempAt: 1 put: nil.
			thisContext terminateTo: ctxt.
			unwindBlock value].
	].
	thisContext terminateTo: self.
	self jump.
