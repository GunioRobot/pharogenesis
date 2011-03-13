duplicate: newGuy from: oldGuy
	"oldGuy has just been duplicated and will stay in this world.  Make sure all the ComponentLikeModel requirements are carried out for the copy.  Ask user to rename it.  "

	newGuy installModelIn: oldGuy pasteUpMorph.
	newGuy copySlotMethodsFrom: oldGuy slotName.