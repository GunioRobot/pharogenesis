veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared."

	super veryDeepInner: deepCopier.
	format _ format veryDeepCopyWith: deepCopier.
	target _ target.					"Weakly copied"
	lastValue _ lastValue veryDeepCopyWith: deepCopier.
	getSelector _ getSelector.			"Symbol"
	putSelector _ putSelector.		"Symbol"
	floatPrecision _ floatPrecision veryDeepCopyWith: deepCopier.
	growable _ growable veryDeepCopyWith: deepCopier.
	stepTime _ stepTime veryDeepCopyWith: deepCopier.
	autoAcceptOnFocusLoss _ autoAcceptOnFocusLoss veryDeepCopyWith: deepCopier.
	minimumWidth _ minimumWidth veryDeepCopyWith: deepCopier.
	maximumWidth _ maximumWidth veryDeepCopyWith: deepCopier.
