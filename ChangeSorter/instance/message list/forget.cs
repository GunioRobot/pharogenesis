forget
	"Drop this method from the changeSet"

	self okToChange ifFalse: [^ self].
	currentSelector ifNotNil: [
		myChangeSet removeSelectorChanges: self selectedMessageName 
			class: self selectedClassOrMetaClass.
		self showChangeSet: myChangeSet]