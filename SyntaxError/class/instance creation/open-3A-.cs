open: aSyntaxError
	"Answer a standard system view whose model is an instance of me."

	| topView |
	topView _ self buildMVCViewOn: aSyntaxError.
	topView controller openNoTerminateDisplayAt: Display extent // 2.
	Cursor normal show.
	Processor activeProcess suspend.
