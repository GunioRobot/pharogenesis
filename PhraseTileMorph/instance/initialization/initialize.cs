initialize
	"Initialize a nascent instance"

	super initialize.
	resultType = #unknown.
	brightenedOnEnter _ false.
	self wrapCentering: #center; cellPositioning: #leftCenter.
	self hResizing: #shrinkWrap.
	borderWidth _ 0.
	self layoutInset: 0.
	self extent: 5@5.  "will grow to fit"
	justGrabbedFromViewer _ true.  "All new PhraseTileMorphs that go through the initialize process (rather than being copied) are placed in viewers; the clones dragged out from them will thus have this set the right way; the drop code resets this to false"
