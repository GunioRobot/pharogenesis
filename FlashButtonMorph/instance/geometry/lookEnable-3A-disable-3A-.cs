lookEnable: list1 disable: list2
	self changed.
	submorphs do:[:m|
		list2 do:[:sym|
			((m valueOfProperty: sym) ifNil:[false]) ifTrue:[m visible: false].
		].
		list1 do:[:sym|
			((m valueOfProperty: sym) ifNil:[false]) ifTrue:[m visible: true].
		].
	].
	self computeBounds.
	self changed.