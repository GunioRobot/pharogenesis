browseVersions
	"Browse the method versions."

	ToolSet default
		browseVersionsOf: self selectedChangeWrapper actualClass
		selector: (self selectedMessageName ifNil: [^self])