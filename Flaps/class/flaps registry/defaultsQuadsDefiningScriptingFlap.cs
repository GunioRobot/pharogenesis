defaultsQuadsDefiningScriptingFlap
	"Answer a structure defining the default items in the Scripting flap.
	previously in quadsDeiningScriptingFlap"

	^ #(
	(TrashCanMorph			new						'Trash'				'A tool for discarding objects')	
	(ScriptingSystem 		scriptControlButtons 			'Status'				'Buttons to run, stop, or single-step scripts')
	(AllScriptsTool			allScriptsToolForActiveWorld	'All Scripts' 		'A tool that lets you control all the running scripts in your world')
	(ScriptingSystem		newScriptingSpace			'Scripting'			'A confined place for drawing and scripting, with its own private stop/step/go buttons.')

	(PaintInvokingMorph	new						'Paint'				'Drop this into an area to start making a fresh painting there')
	(ScriptableButton		authoringPrototype		'Button'			'A Scriptable button')
	(ScriptingSystem		prototypicalHolder 		'Holder'			'A place for storing alternative pictures in an animation, etc.')
	(RandomNumberTile		new		'Random'		'A tile that will produce a random number in a given range')
	(ScriptingSystem		anyButtonPressedTiles	'ButtonDown?'	'Tiles for querying whether the mouse button is down')
	(ScriptingSystem		noButtonPressedTiles		'ButtonUp?'		'Tiles for querying whether the mouse button is up')

	(SimpleSliderMorph		authoringPrototype		'Slider'			'A slider for showing and setting numeric values.')
	(JoystickMorph			authoringPrototype		'Joystick'		'A joystick-like control')
	(TextFieldMorph			exampleBackgroundField		'Scrolling Field'	'A scrolling data field which will have a different value on every card of the background')

	(PasteUpMorph			authoringPrototype		'Playfield'		'A place for assembling parts or for staging animations')


	(StackMorph 			authoringPrototype		'Stack' 			'A multi-card data base'	)
	(TextMorph				exampleBackgroundLabel	'Background Label' 'A piece of text that will occur on every card of the background')
	(TextMorph				exampleBackgroundField		'Background Field'	'A  data field which will have a different value on every card of the background')

		) asOrderedCollection