displayFiltered: evt
	| matchStr allItems isMatch matches feedbackMorph |
	matchStr _ self valueOfProperty: #matchString.
	allItems _ self submorphs select: [:m | m isKindOf: MenuItemMorph].
	matches _  allItems select: [:m | 
		isMatch _ 
			matchStr isEmpty or: [
				m contents includesSubstring: matchStr caseSensitive: false].
		m isEnabled: isMatch.
		isMatch].
	feedbackMorph _ self valueOfProperty: #feedbackMorph.
	feedbackMorph ifNil: [
		feedbackMorph _ 
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
