setTarget: evt
	"Set the default target object to be used for add item commands, and re-target all existing items to the new target or the the invoking hand."

	| rootMorphs old |
	rootMorphs _ self world rootMorphsAt: evt hand targetOffset.
	rootMorphs size > 1
		ifTrue: [defaultTarget _ rootMorphs at: 2]
		ifFalse: [^ self].
	"re-target all existing items"
	self items do: [:item |
		old _ item target.
		old isHandMorph
			ifTrue: [item target: evt hand. evt hand setArgument: defaultTarget]
			ifFalse: [item target: defaultTarget]].
