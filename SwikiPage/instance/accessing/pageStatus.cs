pageStatus
	"The basic stati ;) are #new and #standard. If the pageStatus is nil,
we make make the page #standard, as that is the old behavior. You could add
other types to get e.g., different kinds of URLs, or to exclude pages from
a search, or alter the formatter, or..."
	pageStatus ifNil: [pageStatus _ #standard].
	^pageStatus