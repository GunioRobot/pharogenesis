setId: anID name: aName comment: aComment
	"Initialize receiver"

	id := anID.
	name := aName.
	comment := self removeSeparators: aComment.