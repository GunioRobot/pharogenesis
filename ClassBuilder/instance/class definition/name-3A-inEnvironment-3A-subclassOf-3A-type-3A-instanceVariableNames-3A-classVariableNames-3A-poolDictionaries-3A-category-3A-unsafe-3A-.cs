name: className inEnvironment: env subclassOf: newSuper type: type instanceVariableNames: instVarString classVariableNames: classVarString poolDictionaries: poolString category: category unsafe: unsafe
	"Define a new class in the given environment.
	If unsafe is true do not run any validation checks.
	This facility is provided to implement important system changes."
	| oldClass newClass organization instVars classVars force |
	environ _ env.
	instVars _ Scanner new scanFieldNames: instVarString.
	classVars _ (Scanner new scanFieldNames: classVarString) collect: [:x | x asSymbol].

	"Validate the proposed name"
	unsafe ifFalse:[(self validateClassName: className) ifFalse:[^nil]].
	oldClass _ env at: className ifAbsent:[nil].
	oldClass isBehavior 
		ifFalse:[oldClass _ nil]. "Already checked in #validateClassName:"

	unsafe ifFalse:[
		"Run validation checks so we know that we have a good chance for recompilation"
		(self validateSuperclass: newSuper forSubclass: oldClass) ifFalse:[^nil].
		(self validateInstvars: instVars from: oldClass forSuper: newSuper) ifFalse:[^nil].
		(self validateClassvars: classVars from: oldClass forSuper: newSuper) ifFalse:[^nil].
		(self validateSubclassFormat: type from: oldClass forSuper: newSuper extra: instVars size) ifFalse:[^nil]].

	"Create a template for the new class (will return oldClass when there is no change)"
	newClass _ self 
		newSubclassOf: newSuper 
		type: type 
		instanceVariables: instVars
		from: oldClass
		unsafe: unsafe.

	newClass == nil ifTrue:[^nil]. "Some error"

	newClass == oldClass ifFalse:[newClass setName: className].

	"Install the class variables and pool dictionaries... "
	force _ (newClass declare: classVarString) | (newClass sharing: poolString).

	"... classify ..."
	organization _ environ ifNotNil:[environ organization].
	organization classify: newClass name under: category asSymbol.
	newClass environment: environ.

	"... recompile ..."
	newClass _ self recompile: force from: oldClass to: newClass mutate: false.

	"... export if not yet done ..."
	(environ at: newClass name ifAbsent:[nil]) == newClass ifFalse:[
		environ at: newClass name put: newClass.
		Smalltalk flushClassNameCache.
	].
	"... and fix eventual references to obsolete globals."
	oldClass _ nil. "So we have no references to the old class anymore"
	self fixGlobalReferences.
	self doneCompiling: newClass.
	^newClass
