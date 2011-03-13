processSetBackgroundColor: data
	| color |
	color := data nextColor.
	self recordBackgroundColor: color.
	^true