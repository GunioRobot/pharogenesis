setContainer: newContainer
	"Adopt (or abandon) container shape"
	self changed.
	container _ newContainer.
	self releaseParagraph