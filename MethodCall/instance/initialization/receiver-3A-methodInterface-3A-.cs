receiver: aReceiver methodInterface: aMethodInterface
	"Initialize me to have the given receiver and methodInterface"

	| aResultType |
	receiver _ aReceiver.
	selector _ aMethodInterface selector.
	methodInterface _ aMethodInterface.
	arguments _ aMethodInterface defaultArguments.

	self flag: #noteToTed.
	"the below can't really survive, I know.  The intent is that if the method has a declared result type, we want the preferred readout type to be able to handle the initial #lastValue even if the MethodCall has not been evaluated yet; thus we'd rather have a boolean value such as true rather than a nil here if we're showing a boolean readout such as a checkbox, and likewise for color-valued and numeric-valued readouts etc, "

	(aResultType _ methodInterface resultType) ~~ #unknown ifTrue:
		[lastValue _ (Vocabulary vocabularyForType: aResultType) initialValueForASlotFor: aReceiver]        