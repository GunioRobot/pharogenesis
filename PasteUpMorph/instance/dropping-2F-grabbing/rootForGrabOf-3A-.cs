rootForGrabOf: aMorph
	"If open to drag-n-drop, allow submorph to be extracted. If parts bin, copy the submorph."
	| root |
	root _ aMorph.
	[root = self] whileFalse:
		[root owner == self ifTrue:
			[self isPartsBin
				ifTrue:
					[(root renderedMorph isKindOf: MorphThumbnail)
						ifTrue:
							[^ root renderedMorph morphRepresented veryDeepCopy position: root renderedMorph position]
						ifFalse:
							[^ root topRendererOrSelf veryDeepCopy restoreSuspendedEventHandler ]].
			self dragNDropEnabled
					ifTrue: [^ root]].
		root _ root owner].
	^ super rootForGrabOf: aMorph
