activeClassesByCategory   "ImageSegment activeClassesByCategory"
	"Return a dictionary of active classes by system category.
	Useful for finding kernel categories to minimize swapping."

	| active dict cat list |
	active := self activeClasses.
	dict := Dictionary new.
	active do:
		[:c | cat := c category.
		list := dict at: cat ifAbsent: [Array new].
		dict at: cat put: (list copyWith: c)].
	^ dict
"
	ImageSegment discoverActiveClasses  <-- do it
		-- do something typical --
	ImageSegment activeClassesByCategory  <-- inspect it
"