findWindow
	"Present a menu of window titles, and activate the one that gets chosen.
	Collapsed windows appear below line, expand if chosen."
	| menu expanded collapsed nakedMorphs |
	menu _ MenuMorph new.
	expanded _ SystemWindow windowsIn: self world satisfying: [:w | w isCollapsed not].
	collapsed _ SystemWindow windowsIn: self world satisfying: [:w | w isCollapsed].
	nakedMorphs _ self world submorphsSatisfying:
		[:m | ((m isKindOf: SystemWindow) not and: [(m isKindOf: StickySketchMorph) not]) and:
			[(m isKindOf: FlapTab) not]].
	(expanded isEmpty & (collapsed isEmpty & nakedMorphs isEmpty)) ifTrue: [^ self beep].
	(expanded asSortedCollection: [:w1 :w2 | w1 label caseInsensitiveLessOrEqual: w2 label]) do:
		[:w | menu add: w label target: w action: #activateAndForceLabelToShow.
			w model canDiscardEdits ifFalse: [menu lastItem color: Color red]].
	(expanded isEmpty | (collapsed isEmpty & nakedMorphs isEmpty)) ifFalse: [menu addLine].
	(collapsed asSortedCollection: [:w1 :w2 | w1 label caseInsensitiveLessOrEqual: w2 label]) do: 
		[:w | menu add: w label target: w action: #collapseOrExpand.
		w model canDiscardEdits ifFalse: [menu lastItem color: Color red]].
	nakedMorphs isEmpty ifFalse: [menu addLine].
	(nakedMorphs asSortedCollection: [:w1 :w2 | w1 externalName caseInsensitiveLessOrEqual: w2 externalName]) do:
		[:w | menu add: w externalName target: w action: #comeToFrontAndAddHalo].
	menu addTitle: 'find window'.
	
	self invokeMenu: menu event: lastEvent