primitivePerform
	| performSelector |
	self assertStackPointerIsExternal.
	performSelector _ messageSelector.
	messageSelector _ self stackValue: argumentCount - 1.
	newReceiver _ self stackValue: argumentCount.
	"NOTE: the following lookup may fail and be converted to #doesNotUnderstand:,
		so we must adjust argument count now, so that would work."
	argumentCount _ argumentCount - 1.
	self pushRemappableOop: performSelector.
"**	self lookupMethodInClass: (self fetchClassOf: newReceiver).	**"	"provokes GC!"
	self findNewMethodInClass: (self fetchClassOf: newReceiver).	"provokes GC!"
	performSelector _ self popRemappableOop.
	self success: (self argumentCountOf: newMethod) = argumentCount.
	successFlag ifTrue: [
		"Remove the #perform: from the stack"
		self inlineTransfer:	argumentCount									"N"
			wordsFrom:		self stackPointer - (argumentCount * 4) + 4		"[arg1 arg2 ... argN]"
			to:				self stackPointer - (argumentCount * 4).			"[selector arg1 arg2 ... argN]"
		self pop: 1.
		self executeNewMethod.  "Recursive xeq affects successFlag"
		successFlag _ true.
	] ifFalse: [
		argumentCount _ argumentCount + 1.
		messageSelector _ performSelector.
	]