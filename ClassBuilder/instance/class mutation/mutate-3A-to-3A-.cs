mutate: oldClass to: newClass
	"Mutate the old class and subclasses into newClass and subclasses.
	Note: This method is slightly different from: #mutate:toSuper: since
	here we are at the root of reshaping and have two distinct roots."
	| newSubclass |
	self showProgressFor: oldClass.
	"Convert the subclasses"
	oldClass subclasses do:[:oldSubclass| 
		newSubclass _ self reshapeClass: oldSubclass toSuper: newClass.
		self mutate: oldSubclass to: newSubclass.
	].
	"And any obsolete ones"
	oldClass obsoleteSubclasses do:[:oldSubclass|
		oldSubclass ifNotNil:[
			newSubclass _ self reshapeClass: oldSubclass toSuper: newClass.
			self mutate: oldSubclass to: newSubclass.
		].
	].
	self update: oldClass to: newClass.
	^newClass