validateClassvars: classVarArray from: oldClass forSuper: newSuper
	"Check if any of the classVars of oldClass conflict with the new superclass"
	| usedNames classVars temp |
	classVarArray isEmpty ifTrue:[^true]. "Okay"

	"Validate the class var names"
	usedNames _ classVarArray asSet.
	usedNames size = classVarArray size 
		ifFalse:[	classVarArray do:[:var|
					usedNames remove: var ifAbsent:[temp _ var]].
				self error: temp,' is multiply defined'. ^false].
	(usedNames includesAnyOf: self reservedNames) 
		ifTrue:[	self reservedNames do:[:var|
					(usedNames includes: var) ifTrue:[temp _ var]].
				self error: temp,' is a reserved name'. ^false].

	newSuper == nil ifFalse:[
		usedNames _ newSuper allClassVarNames asSet.
		classVarArray do:[:iv|
			(usedNames includes: iv) ifTrue:[
				newSuper withAllSuperclassesDo:[:cl|
					(cl classVarNames includes: iv) ifTrue:[temp _ cl]].
				self error: iv, ' is already defined in ', temp name.
				^false]]].

	oldClass == nil ifFalse:[
		usedNames _ Set new: 20.
		oldClass allSubclassesDo:[:cl| usedNames addAll: cl classVarNames].
		classVars _ classVarArray.
		newSuper == nil ifFalse:[classVars _ classVars, newSuper allClassVarNames asArray].
		classVars do:[:iv|
			(usedNames includes: iv) ifTrue:[
				self error: iv, ' is already defined in a subclass of ', oldClass name.
				^false]]].
	^true