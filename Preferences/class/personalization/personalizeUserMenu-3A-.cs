personalizeUserMenu: aMenu
	"The user has clicked on the morphic desktop with the yellow mouse button (option+click on the Mac); a menu is being constructed to present to the user in response; its default target is the current world.  In this method, you are invited to add items to the menu as per personal preferences.
	The default implementation, for illustrative purposes, sets the menu title to 'personal', and adds items for go-to-previous-project, show/hide flaps, and load code updates"
	
	aMenu addTitle: 'personal'.  "Remove or modify this as per personal choice"

	aMenu add: 'previous project' action: #goBack.
	aMenu addUpdating: #suppressFlapsString target: Utilities action: #toggleFlapSuppressionInProject.
	aMenu add: 'load latest code updates' target: Utilities action: #updateFromServer