offerGlobalFlapsMenu
	"Put up a menu that lets the user control which global flaps are to be shown in this project"

	| aMenu anItem |
	aMenu _ MenuMorph new defaultTarget: Project current.
	aMenu addTitle: 'Global flaps to
show in this project'.
	aMenu addStayUpItem.
	Utilities globalFlapTabs do:
		[:aFlapTab |
			anItem _ aMenu addUpdating: #globalFlapEnabledString: enablementSelector: nil target: Project current selector: #enableDisableGlobalFlap: argumentList: (Array with: aFlapTab).
			anItem wordingArgument: aFlapTab].
	aMenu popUpForHand: self currentHand in: self currentWorld