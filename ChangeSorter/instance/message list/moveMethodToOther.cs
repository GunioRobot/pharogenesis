moveMethodToOther
	"Place this change in the other changeSet and remove it from this side"
	| other cls sel |
	self checkThatSidesDiffer: [^ self].
	self okToChange ifFalse: [^ self beep].
	currentSelector ifNotNil:
		[other _ (parent other: self) changeSet.
		other == myChangeSet ifTrue: [^ self beep].
		cls _ self selectedClassOrMetaClass.
		sel _ currentSelector asSymbol.
		other absorbMethod: sel class: cls from: myChangeSet.
	
		(parent other: self) showChangeSet: other.
		self forget "removes the method from this side"]
