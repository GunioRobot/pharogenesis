addToggleItemsToHaloMenu: aMenu
	"Add standard true/false-checkbox items to the memu"

	#(
	(resistsRemovalString toggleResistsRemoval 'whether I should be reistant to easy deletion via the pink X handle')
	(stickinessString toggleStickiness 'whether I should be resistant to a drag done by mousing down on me')
	(lockedString lockUnlockMorph 'when "locked", I am inert to all user interactions')
	(hasClipSubmorphsString changeClipSubmorphs 'whether the parts of objects within me that are outside my bounds should be masked.')
	(hasDirectionHandlesString changeDirectionHandles 'whether direction handles are shown with the halo')
	(hasDragAndDropEnabledString changeDragAndDrop 'whether I am open to having objects dropped into me')
	) do:

		[:trip | aMenu addUpdating: trip first action: trip second.
			aMenu balloonTextForLastItem: trip third translated].

	self couldHaveRoundedCorners ifTrue:
		[aMenu addUpdating: #roundedCornersString action: #toggleCornerRounding.
		aMenu balloonTextForLastItem: 'whether my corners should be rounded']