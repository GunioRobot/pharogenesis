checkFatalReshape: setOfClasses
	| suspects oldInstVars newInstVars bad className |
	"Inform the user if any of these classes were reshaped.  A block has a method from the old system whose receiver is of this class.  The method's inst var references might be wrong.  OK if inst vars were only added."

	setOfClasses isEmpty ifTrue: [^ self].
	suspects _ OrderedCollection new.
	setOfClasses do: [:aClass |
		className _ renamed keyAtValue: aClass name ifAbsent: [aClass name].
		oldInstVars _ (structures at: className ifAbsent: [#(0)]) allButFirst.		"should be there"
		newInstVars _ aClass allInstVarNames.
		oldInstVars size > newInstVars size ifTrue: [bad _ true].
		oldInstVars size = newInstVars size ifTrue: [
			bad _ oldInstVars ~= newInstVars].
		oldInstVars size < newInstVars size ifTrue: [
			bad _ oldInstVars ~= (newInstVars copyFrom: 1 to: oldInstVars size)].
		bad ifTrue: [suspects add: aClass]].

	suspects isEmpty ifFalse: [
		self inform: ('Imported foreign methods will run on instances of:\',
			suspects asArray printString, 
			'\whose shape has changed.  Errors may occur.') withCRs].