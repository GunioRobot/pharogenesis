class: clsName category: cat method: method sourceFiles: fileArray
	"This should be enough to find all the information for a method, or method deletion"

	file _ fileArray at: method fileIndex.
	position _ method filePosition.
	type _ #method.
	class _ clsName copyUpTo: $ .	"the non-meta part of a class name"
	category _ cat.
	meta _ clsName endsWith: ' class'.
	self readStamp.