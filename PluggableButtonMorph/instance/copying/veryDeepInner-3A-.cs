veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"model _ model.		Weakly copied"
label _ label veryDeepCopyWith: deepCopier.
"getStateSelector _ getStateSelector.		a Symbol"
"actionSelector _ actionSelector.		a Symbol"
"getLabelSelector _ getLabelSelector.		a Symbol"
"getMenuSelector _ getMenuSelector.		a Symbol"
shortcutCharacter _ shortcutCharacter veryDeepCopyWith: deepCopier.
askBeforeChanging _ askBeforeChanging veryDeepCopyWith: deepCopier.
triggerOnMouseDown _ triggerOnMouseDown veryDeepCopyWith: deepCopier.
offColor _ offColor veryDeepCopyWith: deepCopier.
onColor _ onColor veryDeepCopyWith: deepCopier.
feedbackColor _ feedbackColor veryDeepCopyWith: deepCopier.
showSelectionFeedback _ showSelectionFeedback veryDeepCopyWith: deepCopier.
allButtons _ nil.		"a cache"
arguments _ arguments veryDeepCopyWith: deepCopier.
argumentsProvider _ argumentsProvider veryDeepCopyWith: deepCopier.
argumentsSelector _ argumentsSelector.  " a Symbol" 