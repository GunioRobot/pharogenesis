borderDashOffset

	borderDashSpec size < 4 ifTrue: [^ 0.0].
	^ (borderDashSpec at: 4) asFloat