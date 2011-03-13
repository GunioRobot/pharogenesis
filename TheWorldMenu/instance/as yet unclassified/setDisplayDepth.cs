setDisplayDepth
	"Let the user choose a new depth for the display. "

	| result oldDepth |
	oldDepth _ Display depth.
	(result _ (SelectionMenu selections: Display supportedDisplayDepths) startUpWithCaption:
'Choose a display depth
(it is currently ' , oldDepth printString , ')') ifNotNil: [Display newDepth: result].
	(Smalltalk isMorphic and: [(Display depth < 4) ~= (oldDepth < 4)])
		ifTrue:
			["Repaint windows since they look better all white in depth < 4"
			(SystemWindow windowsIn: myWorld satisfying: [:w | true]) do:
				[:w |
				oldDepth < 4
					ifTrue: [w restoreDefaultPaneColor]
					ifFalse: [w updatePaneColors]]]