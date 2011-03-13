selectLine
	"Make the receiver's selection, if it currently consists of an insertion point only, encompass the current line. 2/29/96 sw"

	| string left right |

	string _ paragraph text string.
	left _ startBlock stringIndex.
	right _ stopBlock stringIndex - 1.
	left > right ifFalse: [^ self].

	[left > 1 and: [(string at: (left - 1)) ~= Character cr]] whileTrue:
		[left _ left - 1].
	[right < string size and: [(string at: (right + 1)) ~= Character cr]] whileTrue:
		[right _ right + 1].
	self selectFrom: left to: (right + 1 min: string size)