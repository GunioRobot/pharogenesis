init: sourceStream notifying: req failBlock: aBlock

	requestor _ req.
	failBlock _ aBlock.
	super scan: sourceStream.
	prevMark _ hereMark _ mark.
	requestorOffset _ 0.
	self advance