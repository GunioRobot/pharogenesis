capturedState
	"Note the state stored in the second element is an array of associations
	from submorph index to a shallowCopy of the morph, but only for those
	morphs that change.  Therefore the capturedState record *first* delivers
	all the morphs, and *then* computes the difference and stores this back.
	In the end, both undo and redo records follow this format."

	| prior state oldMorphs priorChanges newChanges |
	(prior := self valueOfProperty: #priorState) isNil 
		ifTrue: 
			[state := { 
						self shallowCopy.	"selection, etc."
						self submorphs collect: [:m | m shallowCopy].	"state of all tiles"
						owner scoreDisplay flash.	"score display"
						owner scoreDisplay value}.
			self setProperty: #priorState toValue: state.
			^state].
	oldMorphs := prior second.
	priorChanges := OrderedCollection new.
	newChanges := OrderedCollection new.
	1 to: oldMorphs size
		do: 
			[:i | 
			(oldMorphs at: i) color = (submorphs at: i) color 
				ifFalse: 
					[priorChanges addLast: i -> (oldMorphs at: i).
					newChanges addLast: i -> (submorphs at: i) shallowCopy]].
	self removeProperty: #priorState.
	prior at: 2 put: priorChanges asArray.	"Store back into undo state.2"
	^{ 
		self shallowCopy.	"selection, etc."
		newChanges asArray.	"state of tiles that changed"
		owner scoreDisplay flash.	"score display"
		owner scoreDisplay value}