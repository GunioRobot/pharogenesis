buildDebugHandleMenuFor: argMorph
	"Build the menu for the given morph's halo's debug handle."
	argument _ argMorph.
	^ argMorph debuggingMenuFor: self