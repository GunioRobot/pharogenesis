selectedMessage
	"Answer the source code of the currently selected context."
	contents := theMethodNode sourceText.
	^ contents := contents asText makeSelectorBold