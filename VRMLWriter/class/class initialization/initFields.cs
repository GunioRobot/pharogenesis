initFields
	"VRMLWriter initialize"
	| selString multi typeString selector singleString multiString |
	VRMLFieldTypes := Dictionary new.
	#(
MFColor 
MFFloat 
MFInt32 
MFNode 
MFRotation 
MFString 
MFTime 
MFVec2f 
MFVec3f 

	SFBool 
SFColor 
SFFloat 
SFImage 
SFInt32 
SFNode 
SFRotation 
SFString 
SFTime 
SFVec2f 
SFVec3f) do:[:sym|
	multi := sym first = $M.
	typeString := sym copyFrom: 3 to: sym size.
	singleString := 'storeSingleField', typeString, ':on:indent:'.
	multiString := 'writeMultiField', typeString, ':on:indent:'.
	selString := multi ifTrue:[multiString] ifFalse:[singleString].
	selector := selString asSymbol.
	VRMLFieldTypes at: sym asString put: selector.
	(self includesSelector: selector) ifFalse:[
		multi
			ifTrue:[self compileMultiFieldMethod: selString type: typeString]
			ifFalse:[self compileSingleFieldMethod: selString type: typeString]].
]. 