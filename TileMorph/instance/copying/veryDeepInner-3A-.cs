veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
type _ type veryDeepCopyWith: deepCopier.
slotName _ slotName veryDeepCopyWith: deepCopier.
literal _ literal veryDeepCopyWith: deepCopier.
operatorOrExpression _ operatorOrExpression veryDeepCopyWith: deepCopier.
"actualObject _ actualObject.		Weakly copied"
downArrow _ downArrow veryDeepCopyWith: deepCopier.
upArrow _ upArrow veryDeepCopyWith: deepCopier.
suffixArrow _ suffixArrow veryDeepCopyWith: deepCopier.
typeColor _ typeColor veryDeepCopyWith: deepCopier.
lastArrowTick _ lastArrowTick veryDeepCopyWith: deepCopier.
nArrowTicks _ nArrowTicks veryDeepCopyWith: deepCopier.
operatorReadoutString _ operatorReadoutString veryDeepCopyWith: deepCopier.
possessive _ possessive veryDeepCopyWith: deepCopier.            