removeMessage
	"Remove the selected msg from the system.  Real work done by the parent, a ChangeSorter"

	listIndex == 0 ifFalse: [parent removeMessage]