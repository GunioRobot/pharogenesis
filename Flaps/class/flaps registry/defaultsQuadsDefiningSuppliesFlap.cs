defaultsQuadsDefiningSuppliesFlap
	"Answer a list of quads which define the objects to appear in the default Supplies flap.
	previously in quadsDefiningSuppliesFlap"

	^  #(
	(RectangleMorph 		authoringPrototype		'Rectangle' 		'A rectangle')
	(RectangleMorph		roundRectPrototype		'RoundRect'		'A rectangle with rounded corners')
	(EllipseMorph			authoringPrototype		'Ellipse'			'An ellipse or circle')
	(StarMorph				authoringPrototype		'Star'			'A star')
	(CurveMorph			authoringPrototype		'Curve'			'A curve')
	(PolygonMorph			authoringPrototype		'Polygon'		'A straight-sided figure with any number of sides')
	(TextMorph				boldAuthoringPrototype		'Text'			'Text that you can edit into anything you desire.')
	(ImageMorph			authoringPrototype		'Picture'		'A non-editable picture of something')
	(SimpleSliderMorph		authoringPrototype		'Slider'			'A slider for showing and setting numeric values.')
	(PasteUpMorph			authoringPrototype		'Playfield'		'A place for assembling parts or for staging animations')
	(JoystickMorph			authoringPrototype		'Joystick'		'A joystick-like control')
	(ClockMorph				authoringPrototype		'Clock'			'A simple digital clock')
		) asOrderedCollection