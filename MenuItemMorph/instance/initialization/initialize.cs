initialize

	super initialize.
	bounds _ 0@0 extent: 10@10.
	color _ Color black.
	font _ nil.
	contents _ ''.
	hasFocus _ false.
	isEnabled _ true.
	subMenu _ nil.
	isSelected _ false.
	target _ nil.
	selector _ nil.
	arguments _ nil.
