actOnClickFor: anObject
	"MouseDown on this link"
	targetMorph xeqLinkText: evalString withParameter: parameterString.
	^ true