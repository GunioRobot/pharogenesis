openOrDelete
	| oldMorph |
	oldMorph := World submorphs
				detect: [:each | each hasProperty: #morphHierarchy]
				ifNone: [| newMorph | 
					newMorph := self new asMorph.
					newMorph bottomLeft: ActiveHand position.
					newMorph openInWorld.
					newMorph isFullOnScreen
						ifFalse: [newMorph goHome].
					^ self].
	""
	oldMorph delete