setNewPagePrototype
	"Record the current page as the prototype to be copied when inserting new pages."

	currentPage ifNotNil:
		[newPagePrototype _ currentPage fullCopy].
