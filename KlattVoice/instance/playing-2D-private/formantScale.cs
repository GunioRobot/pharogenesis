formantScale
	self flag: #fixThis. "NOTE: this approximation is good only for vocal-tract lengths near 14.4 and 17.3 (and between them)... but it is certainly wrong for lengths such as 10 or 20."
	^ (17.3 - self tract) / (17.3 - 14.4) * 0.175 + 1.0