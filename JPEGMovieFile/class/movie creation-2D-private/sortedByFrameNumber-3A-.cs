sortedByFrameNumber: fileNames
	"Sort the given collection of fileNames by frame number. The frame number is the integer value of the last contiguous sequence of digits in the file name. Omit filenames that do not contain at least one digit; this helps filter out extraneous non-frame files such as the invisible 'Icon' file that may be inserted by some file servers."

	| filtered pairs |
	"select the file names contain at least one digit"
	filtered _ fileNames select: [:fn | fn anySatisfy: [:c | c isDigit]].

	"make array of number, name pairs"
	pairs _ filtered asArray collect: [:fn |
		Array with: (self extractFrameNumberFrom: fn) with: fn].

	"sort the pairs, then answer a collection containing the second element of every pair"
	pairs sort: [:p1 :p2 | p1 first < p2 first].
	^ pairs collect: [:p | p last].
