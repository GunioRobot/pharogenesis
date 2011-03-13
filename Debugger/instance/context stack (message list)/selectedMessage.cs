selectedMessage
	"Answer the source code of the currently selected context."

	contents := theMethodNode sourceText asText.
	theMethodNode isDoIt ifFalse: [
		contents := contents makeSelectorBold].
	^ contents