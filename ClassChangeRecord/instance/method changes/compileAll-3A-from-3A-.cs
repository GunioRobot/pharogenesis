compileAll: newClass from: oldClass
	"Something about this class has changed.  Locally retained methods must be recompiled.
	NOTE:  You might think that if this changeSet is in force, then we can just note
	the new methods but a lower change set may override and be in force which
	would mean that only the overriding copies go recompiled.  Just do it."

	| sel changeType changeRecord newMethod |
	methodChanges associationsDo:
		[:assn | sel _ assn key.  changeRecord _ assn value.
		changeType _ changeRecord changeType.
		(changeType == #add or: [changeType == #change]) ifTrue:
			[newMethod _ newClass
				recompileNonResidentMethod: changeRecord currentMethod
				atSelector: sel from: oldClass.
			changeRecord noteNewMethod: newMethod]]