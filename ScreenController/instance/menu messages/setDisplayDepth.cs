setDisplayDepth
	"Let the user choose a new depth for the display. "

	| result |
	(result _ (SelectionMenu selections: #('1' '2' '4' '8' '16' '32')) startUpWithCaption: 'Choose a display depth') == nil ifFalse:
		[Display newDepth: result asNumber]