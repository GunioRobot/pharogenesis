setDisplayDepth
	"Let the user choose a new depth for the display. "
	| result |
	(result := (SelectionMenu selections: Display supportedDisplayDepths) startUpWithCaption: 'Choose a display depth
(it is currently ' , Display depth printString , ')') == nil ifFalse:
		[Display newDepth: result]