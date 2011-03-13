perform: selector orSendTo: otherTarget
	"Selector was just chosen from a menu by a user.  If I can respond, then perform it on myself.  If not, send it to otherTarget, presumably the editPane from which the menu was invoked." 

	(#accept == selector) ifTrue: [^ self acceptFrom: otherTarget view].
	^ super perform: selector orSendTo: otherTarget