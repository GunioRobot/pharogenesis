endPage
	| stream |
	stream _ WriteStream on: ''.
	stream nextPutAll: '</BODY>';cr;
	 nextPutAll: '</HTML>';cr.
	^stream contents