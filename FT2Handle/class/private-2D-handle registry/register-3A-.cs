register: aHandle

	self registry ifNotNilDo: [ :reg |
		reg add: aHandle.
			^self ].
	self error: 'WeakArrays are not supported in this VM!' 