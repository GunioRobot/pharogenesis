defaultsQuadsDefiningScriptingFlap
	"Answer a structure defining the default items in the Scripting flap.
	previously in quadsDeiningScriptingFlap"

	^ #(
	(SimpleSliderMorph		authoringPrototype		'Slider'			'A slider for showing and setting numeric values.')
	(JoystickMorph			authoringPrototype		'Joystick'		'A joystick-like control')
	(TextFieldMorph			exampleBackgroundField		'Scrolling Field'	'A scrolling data field which will have a different value on every card of the background')

	(PasteUpMorph			authoringPrototype		'Playfield'		'A place for assembling parts or for staging animations')

	(TextMorph				exampleBackgroundLabel	'Background Label' 'A piece of text that will occur on every card of the background')
	(TextMorph				exampleBackgroundField		'Background Field'	'A  data field which will have a different value on every card of the background') ) asOrderedCollection