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
	(ScriptingSystem		prototypicalHolder 		'Holder'			'A place for storing alternative pictures in an animation, etc.')
	(ImageMorph			authoringPrototype		'Picture'		'A non-editable picture of something')
	(ScriptableButton		authoringPrototype		'Button'			'A Scriptable button')
	(SimpleSliderMorph		authoringPrototype		'Slider'			'A slider for showing and setting numeric values.')
	(PasteUpMorph			authoringPrototype		'Playfield'		'A place for assembling parts or for staging animations')
	(BookMorph				authoringPrototype		'Book'			'A multi-paged structure')
	(TabbedPalette			authoringPrototype		'TabbedPalette'	'A structure with tabs')
	(JoystickMorph			authoringPrototype		'Joystick'		'A joystick-like control')
	(ClockMorph				authoringPrototype		'Clock'			'A simple digital clock')
	(BookMorph				previousPageButton 		'PreviousPage'	'A button that takes you to the previous page')
	(BookMorph				nextPageButton			'NextPage'		'A button that takes you to the next page')
		) asOrderedCollection