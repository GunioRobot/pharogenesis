openViewerForArgument
	"Open up a viewer for a player associated with the morph in question.  Temporarily, if shift key is down, open up an instance browser on the morph itself, not the player, with tiles showing, instead"

	ActiveEvent shiftPressed ifTrue:
		[ActiveWorld abandonAllHalos.
		^ self openInstanceBrowserWithTiles].
	self presenter viewMorph: self