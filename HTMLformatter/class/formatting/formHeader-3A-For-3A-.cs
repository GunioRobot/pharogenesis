formHeader: title For: aReference
	"Write the standard header for a page and form for editing anObject."

	self
		title: title;
		reply: '<form action="',aReference,'" method=post><table>'
