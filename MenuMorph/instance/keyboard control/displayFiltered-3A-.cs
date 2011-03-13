displayFiltered: evt
	| matchStr allItems isMatch matches feedbackMorph |
	matchStr := self valueOfProperty: #matchString.
	allItems := self submorphs select: [:m | m isKindOf: MenuItemMorph].
	matches :=  allItems select: [:m | 
		isMatch := 
			matchStr isEmpty or: [
				m contents includesSubstring: matchStr caseSensitive: false].
		m isEnabled: isMatch.
		isMatch].
	feedbackMorph := self valueOfProperty: #feedbackMorph.
	feedbackMorph ifNil: [
		feedbackMorph := 
			TextMorph new 
				autoFit: true;
				color: Color darkGray.
		self
			addLine;
			addMorphBack: feedbackMorph lock.
		self setProperty: #feedbackMorph toValue: feedbackMorph.
		self fullBounds.  "Lay out for submorph adjacency"].
	feedbackMorph contents: '<', matchStr, '>'.
	matchStr isEmpty ifTrue: [
		feedbackMorph delete.
		self submorphs last delete.
		self removeProperty: #feedbackMorph].
	matches size >= 1 ifTrue: [
		self selectItem: matches first event: evt]
