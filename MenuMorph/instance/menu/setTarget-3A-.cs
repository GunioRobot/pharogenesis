setTarget: evt 
	"Set the default target object to be used for add item commands, and re-target all existing items to the new target or the the invoking hand."

	| rootMorphs old |
	rootMorphs := self world rootMorphsAt: evt hand targetOffset.
	rootMorphs size > 1 
		ifTrue: [defaultTarget := rootMorphs second]
		ifFalse: [^self].
	"re-target all existing items"
	self items do: 
			[:item | 
			old := item target.
			old isHandMorph 
				ifTrue: [item target: evt hand]
				ifFalse: [item target: defaultTarget]]