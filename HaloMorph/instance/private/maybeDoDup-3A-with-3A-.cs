maybeDoDup: evt with: dupHandle
	^ target okayToDuplicate ifTrue:
		[self doDup: evt with: dupHandle]