classCommentIndicated
	"Answer true iff we're viewing the class comment."

	^ editSelection == #editComment or: [ self selectedMessageName == #Comment ]