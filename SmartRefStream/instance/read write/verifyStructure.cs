verifyStructure
	"Compare the incoming inst var name lists with the existing classes.  Prepare tables that will help to restructure those who need it (renamed, reshaped, steady).    If all superclasses are recorded in the file, only compare inst vars of this class, not of superclasses.  They will get their turn.  "


| sel newClass oldVer newList newVer oldList ans newShort oldShort converting newlyConverting formerSuper |
converting _ OrderedCollection new.
newlyConverting _ OrderedCollection new.
structures keysDo: [:nm "an old className (symbol)" |


	"For missing classes, there needs to be a method in SmartRefStream like 
		#rectangleoc2 that returns the new class."
	newClass _ self mapClass: nm.	   "does (renamed at: nm put: newClass name)"
	newClass class == String ifTrue: [^ newClass].  "error, fileIn needed"


	oldVer _ self versionSymbol: (structures at: nm).
	newList _ (Array with: newClass classVersion), (newClass allInstVarNames).
	newVer _ self versionSymbol: newList.
	sel _ 'convert',oldVer,':',newVer, ':'. 
		"method name of conversion routine that is send after the object is created."
	oldList _ structures at: nm.
	oldShort _ oldList.     "default unless we know better"
	newShort _ newList.
	superclasses ifNotNil: [
		formerSuper _ superclasses at: nm.
		formerSuper == newClass superclass ifTrue: [
			"just compare inst vars for this class since superclass is also on file"
			oldShort _ oldList copyFrom: (structures at: formerSuper) size + 1 to: oldList size.
			oldShort _ (Array with: (oldList at: 1)), oldShort.     "put version back".
			newShort _ (Array with: newClass classVersion), (newClass instVarNames)
		].
	].
	newList = oldList 
		ifTrue: [steady add: newClass]  "read it in as written"
		ifFalse: [ans _ self verifyClass: newClass was: nm 
					selector: sel newList: newShort oldList: oldShort.
				ans == #exists ifTrue: [converting add: newClass name].
				ans == #new ifTrue: [newlyConverting add: newClass name].
				]].
false & converting isEmpty not ifTrue: ["debug" 
		self inform: 'These classes are being converted from existing methods:\' withCRs,
			converting asArray printString].
newlyConverting isEmpty not ifTrue: [
		self inform: 'Making up new conversion methods for these changed classes\' withCRs,
			newlyConverting asArray printString]