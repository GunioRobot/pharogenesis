terminate 
	"Stop the process that the receiver represents forever.  Unwind to execute pending ensure:/ifCurtailed: blocks before terminating."

	| ctxt unwindBlock |
	self isActiveProcess ifTrue: [
		ctxt _ thisContext.
		[	ctxt _ ctxt findNextUnwindContextUpTo: nil.
			ctxt isNil
		] whileFalse: [
			unwindBlock _ ctxt tempAt: 1.
			unwindBlock ifNotNil: [
				ctxt tempAt: 1 put: nil.
				thisContext terminateTo: ctxt.
				unwindBlock value].
		].
		thisContext terminateTo: nil.
		myList _ nil.
		self primitiveSuspend.
	] ifFalse: [
		myList ifNotNil: [
			myList remove: self ifAbsent: [].
			myList _ nil].
		suspendedContext ifNotNil: [
			ctxt _ self popTo: suspendedContext bottomContext.
			ctxt == suspendedContext bottomContext ifFalse: [
				self debug: ctxt title: 'Unwind error during termination']].
	].
