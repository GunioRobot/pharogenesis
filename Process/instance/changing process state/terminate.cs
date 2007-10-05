terminate 
	"Stop the process that the receiver represents forever.  Unwind to execute pending ensure:/ifCurtailed: blocks before terminating."

	| ctxt unwindBlock inSema |
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
		myList := nil.
		self primitiveSuspend.
	] ifFalse: [
		"Since the receiver is not the active process, drop its priority to rock-bottom so that
		it doesn't accidentally preempt the process that is trying to terminate it."
		priority := 10.
		myList ifNotNil: [
			myList remove: self ifAbsent: [].
			"Figure out if the receiver was terminated while waiting on a Semaphore"
			inSema := myList class == Semaphore.
			myList := nil].
		suspendedContext ifNotNil: [
			"Figure out if we are terminating the process while waiting in Semaphore>>critical:
			In this case, pop the suspendedContext so that we leave the ensure: block inside
			Semaphore>>critical: without signaling the semaphore."
			(inSema == true and:[
				suspendedContext method == (Semaphore compiledMethodAt: #critical:)]) ifTrue:[
					suspendedContext := suspendedContext home.
			].
			ctxt := self popTo: suspendedContext bottomContext.
			ctxt == suspendedContext bottomContext ifFalse: [
				self debug: ctxt title: 'Unwind error during termination']].
	].
