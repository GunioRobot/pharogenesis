browseClass
	"Browse the class of the selected item."

	ToolSet default
		browse: self selectedChangeWrapper actualClass
		selector: self selectedMessageName