recipientForMouseDown: evt
	"Return the morph that should handle the given mouseDown: event."
	"Details: To get mouse events, a morph must
		a. contain the point at which the mouse went down, and
		b. respond true to handlesMouseDown:, and
		c1. be in front of all other submorphs that respond true to handlesMouseDown: or
		c2. be the outer-most submorph that responds true to preemptsMouseDown:
If no morph handles the mouse down, the front-most submorph is grabbed. The complexity in this description arises from the need to resolve conflicts when nested submorphs all want to handle mouse events. The preemptsMouseDown: mechanism allows a morph to intercept mouse events before its submorphs. It is needed only in unusual situations, such as parts bins containing mouse-sensitive objects."

	| p roots coreSample |
	owner ifNil: [^ nil].  "this hand is not in a world"

	p _ evt cursorPoint.
	roots _ owner rootMorphsAt: p.  "root morphs in world"
	roots size = 0 ifTrue: [
		"no morphs at the given point, so world gets it"
		^ owner].

	"coreSample is submorphs of the front-most root morph in front-to-back order"
	coreSample _ roots first unlockedMorphsAt: p.
	coreSample do: [:subM | (subM trumpsMouseDown: evt) ifTrue: [^ subM]].

	"first, look for an outer-most submorph that preempts mouse events, if any"
	coreSample reverseDo: [:subM |
		(subM preemptsMouseDown: evt) ifTrue: [^ subM]].
	"second, look for the inner-most submorph that handles mouse events, if any"
	coreSample do: [:subM |
		(subM handlesMouseDown: evt) ifTrue: [^ subM]].
	"no enclosing morph wants the event, so return the front-most submorph"
	^ coreSample first
