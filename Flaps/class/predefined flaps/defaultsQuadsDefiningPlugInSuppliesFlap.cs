defaultsQuadsDefiningPlugInSuppliesFlap
	"Answer a list of quads which define the objects to appear in the default Supplies flap used in the Plug-in image"

	^  #(
	(GrabPatchMorph		new						'Grab Patch'		'Allows you to create a new Sketch by grabbing a rectangular patch from the screen')
	(LassoPatchMorph		new						'Lasso'		'Allows you to create a new Sketch by lassoing an area from the screen')

	"(StickyPadMorph		newStandAlone			'Sticky Pad'			'Each time you obtain one of these pastel, translucent, borderless rectangles, it will be a different color from the previous time.')
	(PaintInvokingMorph	new						'Paint'				'Drop this into an area to start making a fresh painting there')"
	(TextMorph				boldAuthoringPrototype			'Text'				'Text that you can edit into anything you desire.')
	(RecordingControlsMorph	authoringPrototype		'Sound'				'A device for making sound recordings.')
	(RectangleMorph 		authoringPrototype		'Rectangle' 		'A rectangle')
	(RectangleMorph		roundRectPrototype		'RoundRect'		'A rectangle with rounded corners')
	(EllipseMorph			authoringPrototype		'Ellipse'			'An ellipse or circle')
	(StarMorph				authoringPrototype		'Star'			'A star')
	(CurveMorph			authoringPrototype		'Curve'			'A curve')
	(PolygonMorph			authoringPrototype		'Polygon'		'A straight-sided figure with any number of sides')
	(PasteUpMorph			authoringPrototype		'Playfield'		'A place for assembling parts or for staging animations')
	(SimpleSliderMorph		authoringPrototype		'Slider'			'A slider for showing and setting numeric values.')
	(JoystickMorph			authoringPrototype		'Joystick'		'A joystick-like control')
	(ClockMorph				authoringPrototype		'Clock'			'A simple digital clock')) asOrderedCollection