restore: actionName from: filename
	"Obsolete.  For old format pages only!!!  Get all the info about a Swiki from its folder."

	| action |
	action _ SwikiAction new.
	action name: actionName.
	action source: 'swiki:'.
	action restoreFrom: filename.
	action map pages do: [:each |
		each file: (ServerAction serverDirectory),actionName,(ServerAction
pathSeparator),
			((each file findTokens: (ServerAction pathSeparator)) last)].
	PWS link: actionName to: action.
