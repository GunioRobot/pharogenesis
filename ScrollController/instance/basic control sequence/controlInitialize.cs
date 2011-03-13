controlInitialize
	"Recompute scroll bars.  Save underlying image unless it is already saved."
	| |
	super controlInitialize.
	scrollBar region: (0 @ 0 extent: 24 @ view apparentDisplayBox height).
	scrollBar insideColor: view backgroundColor.
	marker region: self computeMarkerRegion.
	scrollBar := scrollBar align: scrollBar topRight with: view apparentDisplayBox topLeft.
	marker := marker align: marker topCenter with: self upDownLine @ (scrollBar top + 2).
	savedArea isNil ifTrue: [savedArea := Form fromDisplay: scrollBar].
	scrollBar displayOn: Display.

	"Show a border around yellow-button (menu) region"
"
	yellowBar := Rectangle left: self yellowLine right: scrollBar right + 1
		top: scrollBar top bottom: scrollBar bottom.
	Display border: yellowBar width: 1 mask: Form veryLightGray.
"
	self moveMarker
