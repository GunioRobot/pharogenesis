startForm: action
	| stream |
	stream _ WriteStream on: ''.
	stream nextPutAll: '<FORM METHOD="POST" ACTION="', action, '">';
	 cr.
	^ stream contents