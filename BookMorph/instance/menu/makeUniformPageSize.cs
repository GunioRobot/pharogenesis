makeUniformPageSize
	"Make all pages be of the same size as the current page."
	currentPage ifNil: [^ self beep].
	self resizePagesTo: currentPage extent.
	newPagePrototype ifNotNil:
		[newPagePrototype extent: currentPage extent]