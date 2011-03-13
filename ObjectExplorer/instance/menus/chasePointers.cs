chasePointers
	"Open a PointerFinder on the selected item"
	| path sel savedRoot saved |
	path := OrderedCollection new.
	sel := currentSelection.
	[ sel isNil ] whileFalse: [ path addFirst: sel asString. sel := sel parent ].
	path addFirst: #openPath.
	path := path asArray.
	savedRoot := rootObject.
	saved := self object.
	[ rootObject := nil.
	self changed: #getList.
	(Smalltalk includesKey: #PointerFinder)
		ifTrue: [PointerFinder on: saved]
		ifFalse: [self objectReferencesToSelection ]]
		ensure: [ rootObject := savedRoot.
			self changed: #getList.
			self changed: path.
		]