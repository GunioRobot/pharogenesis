moveClassToOther
	"Place class changes in the other changeSet and remove them from this one"

	self copyClassToOther.
	self forgetClass