startUpWithCaption: captionOrNil icon: aForm at: location allowKeyboard: aBoolean 
	"Overridden to return value returned by
	manageMarker. The boolean parameter indicates
	whether the menu should be given keyboard focus"
	| index |
	index := super
				startUpWithCaption: captionOrNil
				icon: aForm
				at: location
				allowKeyboard: aBoolean. 
	^ index
		ifNotNil: [(selections isNil
					or: [(index between: 1 and: selections size) not])
				ifFalse: [selections at: index]]