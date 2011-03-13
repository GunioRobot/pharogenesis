forgetClass
	"Remove all mention of this class from the changeSet"

	self okToChange ifFalse: [^ self].
	currentClassName ifNotNil: [
		myChangeSet removeClassChanges: self selectedClassOrMetaClass.
		currentClassName _ nil.
		currentSelector _ nil.
		self showChangeSet: myChangeSet].
