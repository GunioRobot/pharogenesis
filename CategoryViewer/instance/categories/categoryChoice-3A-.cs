categoryChoice: aCategory
	"Temporarily switch-hits in support of two competing ui designs for the list"
	| bin actualPane |
	((actualPane _ namePane renderedMorph) isKindOf: StringMorph)
		ifTrue:
			[namePane contents: aCategory; color: Color black]
		ifFalse:
			[(actualPane isKindOf: RectangleMorph)
				ifTrue:	[actualPane firstSubmorph contents: aCategory; color: Color black.
						actualPane extent: actualPane firstSubmorph extent]
				ifFalse:
					[actualPane selection: (scriptedPlayer categories indexOf: aCategory)]].

	bin _ PhraseWrapperMorph new borderWidth: 0; listDirection: #topToBottom.
	bin addAllMorphs:
		((scriptedPlayer tilePhrasesForCategory: aCategory inViewer: self) collect:
			[:aViewerRow | self viewerEntryFor: aViewerRow]).
	bin enforceTileColorPolicy.
	submorphs size < 2
		ifTrue:
			[self addMorphBack: bin]
		ifFalse:
			[self replaceSubmorph: self listPane by: bin].
	self world ifNotNil: [self world startSteppingSubmorphsOf: self]

