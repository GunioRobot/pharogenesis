computeFormat: type instSize: newInstSize forSuper: newSuper ccIndex: ccIndex
	"Compute the new format for making oldClass a subclass of newSuper.
	Return the format or nil if there is any problem."
	| instSize isVar isWords isPointers isWeak |
	instSize _ newInstSize + (newSuper ifNil:[0] ifNotNil:[newSuper instSize]).
	instSize > 254 ifTrue:[
		self error: 'Class has too many instance variables (', instSize printString,')'.
		^nil].
	type == #compiledMethod
		ifTrue:[^CompiledMethod instSpec].
	type == #normal ifTrue:[isVar _ isWeak _ false. isWords _ isPointers _ true].
	type == #bytes ifTrue:[isVar _ true. isWords _ isPointers _ isWeak _ false].
	type == #words ifTrue:[isVar _ isWords _ true. isPointers _ isWeak _ false].
	type == #variable ifTrue:[isVar _ isPointers _ isWords _ true. isWeak _ false].
	type == #weak ifTrue:[isVar _ isWeak _ isWords _ isPointers _ true].
	(isPointers not and:[instSize > 0]) ifTrue:[
		self error:'A non-pointer class cannot have instance variables'.
		^nil].
	^(self format: instSize 
		variable: isVar 
		words: isWords 
		pointers: isPointers 
		weak: isWeak) + (ccIndex bitShift: 11).