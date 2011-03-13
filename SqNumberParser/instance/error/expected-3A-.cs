expected: errorString 
	requestor isNil
		ifFalse: [requestor
				notify: errorString , ' ->'
				at: sourceStream position
				in: sourceStream].
	self fail