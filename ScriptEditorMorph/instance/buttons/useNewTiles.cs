useNewTiles
	| ww |
	"At the next request for textual script, use new tiles instead.  Make that request."

	ww _ self bestGuessOfCurrentWorld.
	(ww valueOfProperty: #universalTiles ifAbsent: [false]) ifFalse: [
		ww setProperty: #universalTiles toValue: true.
	 		"for all scriptors and viewers in this world"
		"force viewers to be recreated"
		ww flapTabs do: [:ff | (ff isMemberOf: ViewerFlapTab) ifTrue: [
							ff referent delete.  ff delete]].
		Utilities clobberFlapTabList].
	Preferences enable: #capitalizedReferences.
	self showSourceInScriptor.   "**This does way more than necess, AND kills the shrinkWrap..."
	self hResizing: #shrinkWrap;
		vResizing: #shrinkWrap;
		cellPositioning: #topLeft.
