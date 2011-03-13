addStandardControls
	|  aControl |

	self addStopStepGoButtonsTo: associatedMorph.
	self addLeftHandButtons.
 	self "er, add..." standardPlayer.
	self addTrashCan.

	"Save button"
	aControl _ SimpleButtonMorph newSticky position: (380 @ (associatedMorph height - 30)).
	aControl label: 'Save'; setProperty: #scriptingControl toValue: true.
	aControl target: self; actionSelector: #saveOnFile.
	associatedMorph addMorph: aControl
