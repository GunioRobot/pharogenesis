processSetBackgroundColor: data
	| color |
	color _ data nextColor.
	self recordBackgroundColor: color.
	^true