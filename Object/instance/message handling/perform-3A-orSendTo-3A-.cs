perform: selector orSendTo: otherTarget
	"If I wish to intercept and handle selector myself, do it; else send it to otherTarget"
	^ otherTarget perform: selector