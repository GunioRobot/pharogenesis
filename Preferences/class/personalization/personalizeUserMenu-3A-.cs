personalizeUserMenu: aMenu
	"The user has clicked on the morphic desktop with the yellow mouse button (option+click on the Mac); a menu is being constructed to present to the user in response; its default target is the current world.  In this method, you are invited to add items to the menu as per personal preferences.
	The default implementation, for illustrative purposes, sets the menu title to 'personal', and adds items for go-to-previous-project, show/hide flaps, and load code updates"
	
	aMenu addTitle: 'personal' translated.  "Remove or modify this as per personal choice"

	aMenu addStayUpItem.
	aMenu add: 'previous project' translated action: #goBack.
	aMenu add: 'load latest code updates' translated target: Utilities action: #updateFromServer.
	aMenu add: 'about this system...' translated target: SmalltalkImage current action: #aboutThisSystem.
	Preferences isFlagship ifTrue:
		"For benefit of Alan"
		[aMenu addLine.
		aMenu add: 'start using vectors' translated target: ActiveWorld action: #installVectorVocabulary.
		aMenu add: 'stop using vectors' translated target: ActiveWorld action: #abandonVocabularyPreference].
	aMenu addLine.
				
	aMenu addUpdating: #suppressFlapsString target: CurrentProjectRefactoring action: #currentToggleFlapsSuppressed.
	aMenu balloonTextForLastItem: 'Whether prevailing flaps should be shown in the project right now or not.' translated