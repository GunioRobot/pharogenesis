fetchDocPane
	"Look on servers to see if there is documentation pane for the selected message. Take into account the current update number.  If not, ask the user if she wants to create one."

	DocLibrary external fetchDocSel: self selectedMessageName 
		class: self selectedClassName