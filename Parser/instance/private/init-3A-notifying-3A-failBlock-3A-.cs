init: sourceStream notifying: req failBlock: aBlock

	requestor := req.
	failBlock := aBlock.
	super scan: sourceStream.
	prevMark := hereMark := mark.
	requestorOffset := 0.
	self advance