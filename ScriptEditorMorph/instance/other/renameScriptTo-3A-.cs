renameScriptTo: newSelector
	"Rename the receiver's script so that it has given new selector"

	| labelButton |
	scriptName _ newSelector.
	labelButton _ self firstSubmorph submorphs seventh.
	labelButton label: (playerScripted externalName, ' ', self scriptTitle) font: Preferences standardButtonFont.
	self install