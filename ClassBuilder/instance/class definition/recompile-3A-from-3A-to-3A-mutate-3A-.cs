recompile: force from: oldClass to: aClass mutate: forceMutation
	"Do the necessary recompilation after changine oldClass to newClass.
	If required (e.g., when oldClass ~~ newClass) mutate oldClass to newClass
	and all its subclasses. If forceMutation is true force a mutation even
	if oldClass and newClass are the same."
	| newClass |
	newClass _ aClass.

	oldClass == nil ifTrue:[
		"newClass has an empty method dictionary
		so we don't need to recompile"
		Smalltalk changes addClass: newClass.
		newClass superclass addSubclass: newClass.
		^newClass].

	(newClass == oldClass and:[force not and:[forceMutation not]]) ifTrue:[
		"No recompilation necessary but we might have added
		class vars or class pools so record the change"
		Smalltalk changes changeClass: newClass from: oldClass.
		^newClass].

	currentClassIndex _ 0.
	maxClassIndex _ oldClass withAllSubclasses size.

	(oldClass == newClass and:[forceMutation not]) ifTrue:[
		Smalltalk changes changeClass: newClass from: oldClass.
		"Recompile from newClass without mutating"
		self informUserDuring:[
			newClass isSystemDefined ifFalse:[progress _ nil].
			newClass withAllSubclassesDo:[:cl|
				self showProgressFor: cl.
				cl compileAll]].
		^newClass].
	"Recompile and mutate oldClass to newClass"
	classMap _ WeakValueDictionary new.
	self informUserDuring:[
		newClass isSystemDefined ifFalse:[progress _ nil].
		self showProgressFor: oldClass.
		newClass _ self reshapeClass: oldClass to: newClass super: newClass superclass.
		Smalltalk changes changeClass: newClass from: oldClass.
		self mutate: oldClass to: newClass.
	].
	^newClass