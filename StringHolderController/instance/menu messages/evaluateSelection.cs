evaluateSelection
	"Treat the current text selection as an expression; evaluate it.
	If the left shift key is down, wait for mouse click, then restore the display"
	| result saveBits |

	self lineSelectAndEmptyCheck: [^ ''].

	(saveBits _ sensor leftShiftDown)
		ifTrue: [view topView deEmphasize; cacheBits].
	result _ model doItReceiver class evaluatorClass new
				evaluate: self selectionAsStream
				in: model doItContext
				to: model doItReceiver
				notifying: self
				ifFail: [self controlInitialize.
						saveBits ifTrue: [view topView emphasize].
						^ #failedDoit].
	Smalltalk logChange: self selection string.
	saveBits
		ifTrue: [sensor waitClickButton. ScheduledControllers restore].
	^result