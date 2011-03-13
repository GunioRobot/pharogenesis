topmostInactiveTextController
	"Answer the controller of the window just below the topmost window.  1/31/96 sw"

	| aView |
	scheduledControllers doWithIndex: [:ctrlr :i |
		( i > 1 & ctrlr isKindOf: StandardSystemController)
			ifTrue:
				[(aView _ ctrlr view textEditorView) ~~ nil
					ifTrue:
						[^ aView controller]]].
	^ nil