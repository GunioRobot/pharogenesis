selectedMessage
	"Answer the source code of the currently selected context."
	^contents := self selectedContext debuggerMap sourceText asText makeSelectorBold