setDisplayDepth
	"Let the user choose a new depth for the display. "

	| result oldDepth allDepths allLabels menu hasBoth |
	oldDepth _ Display nativeDepth.
	allDepths _ #(1 -1 2 -2 4 -4 8 -8 16 -16 32 -32) select: [:d | Display supportsDisplayDepth: d].
	hasBoth _ (allDepths anySatisfy:[:d| d > 0]) and:[allDepths anySatisfy:[:d| d < 0]].
	allLabels _ allDepths collect:[:d|
		String streamContents:[:s|
			s nextPutAll: (d = oldDepth ifTrue:['<on>'] ifFalse:['<off>']).
			s print: d abs.
			hasBoth ifTrue:[s nextPutAll: (d > 0 ifTrue:['  (big endian)'] ifFalse:['  (little endian)'])].
		]].
	menu _ SelectionMenu labels: allLabels selections: allDepths.
	result _ menu startUpWithCaption: 'Choose a display depth' translated.
	result ifNotNil: [Display newDepth: result].
	oldDepth _ oldDepth abs.
	(Smalltalk isMorphic and: [(Display depth < 4) ~= (oldDepth < 4)])
		ifTrue:
			["Repaint windows since they look better all white in depth < 4"
			(SystemWindow windowsIn: myWorld satisfying: [:w | true]) do:
				[:w |
				oldDepth < 4
					ifTrue: [w restoreDefaultPaneColor]
					ifFalse: [w updatePaneColors]]]