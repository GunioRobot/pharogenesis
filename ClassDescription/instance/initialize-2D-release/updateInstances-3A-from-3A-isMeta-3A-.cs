updateInstances: oldInstances from: oldClass isMeta: isMeta
	"Recreate any existing instances of the argument, oldClass, as instances of the receiver, which is a newly changed class. Permute variables as necessary. Return the array of old instances (none of which should be pointed to legally by anyone but the array)."
	"If there are any contexts having an old instance as receiver it might crash the system because the layout has changed, and the method only knows about the old layout."
	| map variable instSize newInstances |

	oldInstances isEmpty ifTrue:[^#()]. "no instances to convert"
	isMeta ifTrue: [
		oldInstances size = 1 ifFalse:[^self error:'Metaclasses can only have one instance'].
		self soleInstance class == self ifTrue:[
			^self error:'Metaclasses can only have one instance']].
	map _ self instVarMappingFrom: oldClass.
	variable _ self isVariable.
	instSize _ self instSize.
	newInstances _ Array new: oldInstances size.
	1 to: oldInstances size do:[:i|
		newInstances at: i put: (
			self newInstanceFrom: (oldInstances at: i) variable: variable size: instSize map: map)].
	"Now perform a bulk mutation of old instances into new ones"
	oldInstances elementsExchangeIdentityWith: newInstances.
	^newInstances "which are now old"