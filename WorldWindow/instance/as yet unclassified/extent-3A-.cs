extent: x

	super extent: x.
	model ifNil: [^self].
	model extent: self panelRect extent.