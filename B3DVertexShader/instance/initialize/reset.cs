reset
	super reset.
	lights _ OrderedCollection new.
	material _ B3DMaterial new.
	materialStack _ OrderedCollection new: 10.