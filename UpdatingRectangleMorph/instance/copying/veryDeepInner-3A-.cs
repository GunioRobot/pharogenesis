veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"target _ target.		Weakly copied"
lastValue _ lastValue veryDeepCopyWith: deepCopier.
"getSelector _ getSelector.		a Symbol"
"putSelector _ putSelector.		a Symbol"
contents _ contents veryDeepCopyWith: deepCopier.