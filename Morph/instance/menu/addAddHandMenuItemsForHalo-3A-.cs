addAddHandMenuItemsForHalo: aMenu
	"Add halo menu items to be handled by the invoking hand. The halo menu is invoked by clicking on the menu-handle of the receiver's halo."

	| unlockables |
	aMenu add: 'poof' action: #dismissMorph.
	aMenu addLine.

	aMenu add: 'lock' action: #lockMorph.
	unlockables _ self submorphs select: [:m | m isLocked].
	unlockables size == 1 ifTrue: [
		aMenu add: 'unlock "', unlockables first externalName, '"' action: #unlockContents].
	unlockables size > 1 ifTrue: [
		aMenu add: 'unlock all contents' action: #unlockContents.
		aMenu add: 'unlock...' action: #unlockOneSubpart].
	aMenu addLine.

	aMenu add: 'go behind' action: #goBehind.
	aMenu add: 'rename me' action: #chooseActorName.
	self colorSettable ifTrue: [
		aMenu add: 'fill color' action: #changeColor].
	aMenu addLine.

	(Preferences valueOfFlag: #hackerMode) ifTrue: [
		aMenu add: 'inspect' action: #inspectMorph.
		aMenu add: 'browse' action: #browseMorphClass.
		aMenu add: 'make own subclass' action: #subclassMorph.
		aMenu addLine.

		aMenu add: 'internal name' action: #nameMorph.
		aMenu add: 'save morph in file' action: #saveMorphInFile.
		aMenu addLine].
