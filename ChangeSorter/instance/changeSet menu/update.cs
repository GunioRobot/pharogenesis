update
	"recompute all of my panes"

	self okToChange ifFalse: [^ self].
	self showChangeSet: myChangeSet.
	parent ifNotNil: [
		(parent other: self) okToChange ifTrue: [
			(parent other: self) showChangeSet: 
				(parent other: self) myChangeSet]].