initialize
	super initialize.
	requests := SharedQueue new.
	downloads := OrderedCollection new