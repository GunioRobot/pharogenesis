findATranscript: evt
	"Locate a transcript, open it, and bring it to the front.  Create one if necessary"

	| aWindow |
	submorphs do:
		[:aMorph | (((aWindow _ aMorph renderedMorph) isKindOf: SystemWindow) and:
			[aWindow model == Transcript])
				ifTrue:
					[aWindow isCollapsed ifTrue: [aWindow expand].
					aWindow activateAndForceLabelToShow.
					^ self]].
	"None found, so create one"
	(Transcript openAsMorphLabel: 'Transcript') openInWorld: evt hand world