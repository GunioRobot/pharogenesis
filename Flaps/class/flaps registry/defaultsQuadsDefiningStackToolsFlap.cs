defaultsQuadsDefiningStackToolsFlap
	"Answer a structure defining the items on the default system Stack Tools flap.
	previously in quadsDefiningStackToolsFlap"

	^ #(
	(StackMorph 			authoringPrototype		'Stack' 				'A multi-card data base'	)
	(StackMorph			stackHelpWindow		'Stack Help'			'Some hints about how to use Stacks')
	(TextMorph				authoringPrototype		'Simple Text'		'Text that you can edit into anything you wish')
	(TextMorph				fancyPrototype			'Fancy Text' 		'A text field with a rounded shadowed border, with a fancy font.')
	(ScrollableField			newStandAlone			'Scrolling Text'		'Holds any amount of text; has a scroll bar')
	(ScriptableButton		authoringPrototype		'Scriptable Button'	'A button whose script will be a method of the background Player')
	(StackMorph			previousCardButton 		'Previous Card' 		'A button that takes the user to the previous card in the stack')
	(StackMorph			nextCardButton			'Next Card'			'A button that takes the user to the next card in the stack')) asOrderedCollection
