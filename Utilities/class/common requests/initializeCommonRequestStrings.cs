initializeCommonRequestStrings
	"Initialize an array of common request strings.  2/1/96 sw
	 5/10/96 sw: converted over to new format of StringHolder"

	CommonRequestStrings _ StringHolder new contents: 
'Utilities emergencyCollapse
Sensor keyboard
Cursor normal show
-----------------------------------------------------
Utilities durableHelpMenu
Utilities durableOpenMenu
Utilities durableWindowMenu
Utilities durableChangesMenu
Utilities fontSizeSummary
-----------------------------------------------------
ProjectView open: Project newMorphic
Form fromUser bitEdit
Undeclared inspect
Undeclared removeUnreferencedKeys
Transcript clear'

"Utilities initializeCommonRequestStrings"