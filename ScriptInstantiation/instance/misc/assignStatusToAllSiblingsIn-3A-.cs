assignStatusToAllSiblingsIn: aStatusViewer
	"Let all sibling instances of my player have the same status that I do"

	self assignStatusToAllSiblings.
	self currentWorld presenter updateContentsFor: aStatusViewer 