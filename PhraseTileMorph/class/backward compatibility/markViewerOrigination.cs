markViewerOrigination
	"For bringing old content forward"

	| hadIt gotIt didntWantIt |
	hadIt _ 0.
	gotIt _ 0.
	didntWantIt _ 0.
	self allSubInstancesDo:
		[:m | (m ownerThatIsA: CategoryViewer)
			ifNil:
				[m justGrabbedFromViewer: false.
				didntWantIt _ didntWantIt + 1]
			ifNotNil:
				[(m justGrabbedFromViewerOrNil == true)
					ifTrue:
						[hadIt _ hadIt + 1]
					ifFalse:
						[m justGrabbedFromViewer: true.
						gotIt _ gotIt + 1]]].
	Transcript cr; show: 'updating phrase tiles -- already ok: '; show: hadIt; show: '  marked as in-viewer: '; show: gotIt; show: '  marked as not-in-viewer: '; show: didntWantIt.

	"PhraseTileMorph markViewerOrigination"