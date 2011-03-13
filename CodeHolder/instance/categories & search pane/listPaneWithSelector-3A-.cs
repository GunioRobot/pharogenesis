listPaneWithSelector: aSelector
	"If, among my window's paneMorphs, there is a list pane defined with aSelector as its retriever, answer it, else answer nil"

	| aWindow |
	^ (aWindow := self containingWindow) ifNotNil:
		[aWindow paneMorphSatisfying:
			[:aMorph | (aMorph isKindOf: PluggableListMorph) and:
				[aMorph getListSelector == aSelector]]]