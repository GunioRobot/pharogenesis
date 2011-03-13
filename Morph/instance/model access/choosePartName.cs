choosePartName
	"Pick an unused name for this morph."
	| className |
	(self world model isKindOf: Component) ifTrue:
		[self knownName ifNil: [^ self nameMeIn: self world]
					ifNotNil: [^ self renameMe]].
	className _ self class name.
	(className size > 5 and: [className endsWith: 'Morph'])
		ifTrue: [className _ className copyFrom: 1 to: className size - 5].
	^ self world model addPartNameLike: className withValue: self