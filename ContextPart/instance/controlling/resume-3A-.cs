resume: value
	"Unwind thisContext to self and resume with value as result of last send.  Execute unwind blocks when unwinding.  ASSUMES self is a sender of thisContext"

	| ctxt unwindBlock |
	self isDead ifTrue: [self cannotReturn: value to: self].
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
	^ value
