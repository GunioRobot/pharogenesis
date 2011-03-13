useLogDisplay: aBoolean

	displayType _ aBoolean ifTrue: [#logScale] ifFalse: [#linear].
	self formChanged.
