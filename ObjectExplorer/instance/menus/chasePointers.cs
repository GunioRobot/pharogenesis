chasePointers
	"Open a PointerFinder on the selected item"
	| path sel savedRoot saved |
	path _ OrderedCollection new.
	sel _ currentSelection.
	[ sel isNil ] whileFalse: [ path addFirst: sel asString. sel _ sel parent ].
	path addFirst: #openPath.
	path _ path asArray.
	savedRoot _ rootObject.
	saved _ self object.
	[ rootObject _ nil.
	self changed: #getList.
	(Smalltalk includesKey: #PointerFinder)
		ifTrue: [PointerFinder on: saved]
		ifFalse: [self objectReferencesToSelection ]]
		ensure: [ rootObject _ savedRoot.
			self changed: #getList.
			self changed: path.
		]