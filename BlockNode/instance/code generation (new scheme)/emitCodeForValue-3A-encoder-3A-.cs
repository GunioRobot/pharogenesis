emitCodeForValue: stack encoder: encoder

	self generateAsClosure ifTrue:
		[^self emitCodeForClosureValue: stack encoder: encoder].
	encoder genPushThisContext.
	stack push: 1.
	nArgsNode emitCodeForValue: stack encoder: encoder.
	remoteCopyNode
		emitCode: stack
		args: 1
		encoder: encoder.
	"Force a two byte jump."
	encoder genJumpLong: size.
	stack push: arguments size.
	arguments reverseDo: [:arg | arg emitCodeForStorePop: stack encoder: encoder].
	self emitCodeForEvaluatedValue: stack encoder: encoder.
	self returns ifFalse:
		[encoder genReturnTopToCaller.
		pc := encoder methodStreamPosition].
	stack pop: 1