terminate 
	"Stop the process that the receiver represents forever.  Unwind to execute pending ensure:/ifCurtailed: blocks before terminating."

	| ctxt unwindBlock oldList |
	self isActiveProcess ifTrue: [
		ctxt := thisContext.
		[	ctxt := ctxt findNextUnwindContextUpTo: nil.
			ctxt isNil
		] whileFalse: [
			unwindBlock := ctxt tempAt: 1.
			unwindBlock ifNotNil: [
				ctxt tempAt: 1 put: nil.
				thisContext terminateTo: ctxt.
				unwindBlock value].
		].
		thisContext terminateTo: nil.
		self suspend.
	] ifFalse:[
		myList ifNotNil:[oldList := self suspend].
		suspendedContext ifNotNil:[
			"Figure out if we are terminating the process while waiting in Semaphore>>critical:
			In this case, pop the suspendedContext so that we leave the ensure: block inside
			Semaphore>>critical: without signaling the semaphore."
			(oldList class == Semaphore and:[
				suspendedContext method == (Semaphore compiledMethodAt: #critical:)]) ifTrue:[
					suspendedContext := suspendedContext home.
			].
			ctxt := self popTo: suspendedContext bottomContext.
			ctxt == suspendedContext bottomContext ifFalse: [
				self debug: ctxt title: 'Unwind error during termination']].
	].
