askRenames: renamed addTo: msgSet using: smart
	| list rec ans oldStruct newStruct |
	"Go through the renamed classes.  Ask the user if it could be in a project.  Add a method in SmartRefStream, and a conversion method in the new class."

	list _ OrderedCollection new.
	renamed do: [:cls |
		rec _ changeRecords at: cls name.
		rec priorName ifNotNil: [
			ans _ PopUpMenu withCaption: 'You renamed class ', rec priorName, 
				' to be ', rec thisName,
				'.\Could an instance of ', rec priorName, 
				' be in a project on someone''s disk?'
			chooseFrom: #('Yes, write code to convert those instances'
				'No, no instances are in projects').
			ans = 1 ifTrue: [
					oldStruct _ structures at: rec priorName ifAbsent: [nil].
					newStruct _ (Array with: cls classVersion), (cls allInstVarNames).
					oldStruct ifNotNil: [
						smart writeConversionMethodIn: cls fromInstVars: oldStruct 
								to: newStruct renamedFrom: rec priorName.
						smart writeClassRename: cls name was: rec priorName.
						list add: cls name, ' convertToCurrentVersion:refStream:']]
				ifFalse: [structures removeKey: rec priorName ifAbsent: []]]].
	list isEmpty ifTrue: [^ msgSet].
	msgSet messageList ifNil: [msgSet initializeMessageList: list]
		ifNotNil: [list do: [:item | msgSet addItem: item]].
	^ msgSet