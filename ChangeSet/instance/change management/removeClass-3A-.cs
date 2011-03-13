removeClass: class 
	"Include indication that a class has been forgotten."
	| cName |
	(self isNew: class) ifTrue:
		[^ self removeClassChanges: class]. 	"only remember old classes"
	cName _ (self atClass: class includes: #rename) 	"remember as old name"
		ifTrue: [self oldNameFor: class]
		ifFalse: [class name].
	self removeClassChanges: class.
	classRemoves add: cName