restoreSavedPatchOn: aCanvas
	"Clear the changed flag and restore the part of the given canvas under this hand from the previously saved patch. If necessary, handle the transition to using the hardware cursor."

	hasChanged _ false.
	savedPatch ifNotNil: [
		aCanvas image: savedPatch at: savedPatch offset.

		((userInitials size = 0) and:
		 [(submorphs size = 0) and:
		 [temporaryCursor == nil]]) ifTrue: [
			"Make the transition to using hardware cursor. Clear savedPatch and
			 report one final damage rectangle to erase the image of the software cursor."
			super invalidRect: (savedPatch offset extent: savedPatch extent + self shadowOffset).
			Sensor currentCursor == Cursor normal ifFalse: [Cursor normal show].  "show hardware cursor"
			savedPatch _ nil]].
