initFields
	"VRMLNodeParser initialize"
	| selString multi typeString singleString multiString selector sym type |
	VRMLFieldTypes := Dictionary new.
#(
(MFColor B3DColor4Array)
(MFFloat B3DFloatArray)
(MFInt32 IntegerArray)
(MFNode Array)
(MFRotation B3DRotationArray)
(MFString Array)
(MFTime Array)
(MFVec2f B3DVector2Array)
(MFVec3f B3DVector3Array)
(SFBool)
(SFColor) 
(SFFloat)
(SFImage)
(SFInt32)
(SFNode)
(SFRotation)
(SFString)
(SFTime)
(SFVec2f)
(SFVec3f)
) do:[:spec|
	sym _ spec first.
	type _ spec last.
	multi := sym first = $M.
	typeString := sym copyFrom: 3 to: sym size.
	singleString := 'readSingleField', typeString, 'From:'.
	multiString := 'readMultiField', typeString, 'From:'.
	selString := multi ifTrue:[multiString] ifFalse:[singleString].
	selector := selString asSymbol.
	VRMLFieldTypes at: sym asString put: selector.
	(self includesSelector: selector) ifFalse:[
		multi
			ifTrue:[self compileMultiFieldMethod: selString single: singleString type: type]
			ifFalse:[self compileSingleFieldMethod: selString type: typeString]].
]. 