verifyStructure
	"Compare the incoming inst var name lists with the existing classes.  Prepare tables that will help to restructure those who need it (renamed, reshaped, steady).    If all superclasses are recorded in the file, only compare inst vars of this class, not of superclasses.  They will get their turn.  "

| sel newClass oldVer newList newVer oldList ans newShort oldShort sup |
structures keysDo: [:nm "an old className (symbol)" |
	"For missing classes, there needs to be a method in SmartRefStream like 
		#rectangleoc2 that returns the new class."
	newClass _ self mapClass: nm.		"does (renamed at: nm put: newClass name)"
	newClass class == String ifTrue: [^ newClass].	"error, fileIn needed"

	oldVer _ self versionSymbol: (structures at: nm).
	newList _ (Array with: newClass classVersion), (newClass allInstVarNames).
	newVer _ self versionSymbol: newList.
	sel _ 'convert',oldVer,':',newVer, ':'.	
		"method name of conversion routine that is send after the object is created."
	oldList _ structures at: nm.
	superclasses ifNil: [newShort _ newList.  oldShort _ oldList]
		ifNotNil: ["just compare inst vars for this class"
			sup _ superclasses at: nm.
			oldShort _ sup = 'nil' 
				ifFalse: [oldList copyFrom: (structures at: sup) size + 1 to: oldList size]
				ifTrue: [oldList copyFrom: 2 to: oldList size].
			oldShort _ (Array with: (oldList at: 1)), oldShort.	"put version back".
			newShort _ (Array with: newClass classVersion), (newClass instVarNames)].
	newList = oldList 
		ifTrue: [steady add: newClass]	"read it in as written"
		ifFalse: [ans _ self verifyClass: newClass was: nm 
					selector: sel newList: newShort oldList: oldShort.
			ans = 'conversion method needed' ifTrue: [^ ans]]].