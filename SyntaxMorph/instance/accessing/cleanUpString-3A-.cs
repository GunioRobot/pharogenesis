cleanUpString: stringSubMorph

	| style rawData |
	^ stringSubMorph 
		valueOfProperty: #syntacticallyCorrectContents 
		ifAbsent: [
			style _ stringSubMorph valueOfProperty: #syntacticReformatting.
			rawData _ stringSubMorph contents.
			 (#(unary tempVariableDeclaration blockarg2 methodHeader1 tempVariable variable) includes: style) ifTrue: [
				rawData _ self unSpaceAndUpShift: rawData appending: nil.
			].
			style == #keywordGetz ifTrue: [
				rawData _ self unSpaceAndUpShift: rawData appending: 'Getz:'.
			].
			style == #keywordSetter ifTrue: [
				rawData _ self unSpaceAndUpShift: 'set ',rawData appending: ':'.
			].
			style == #unaryGetter ifTrue: [
				rawData _ self unSpaceAndUpShift: 'get ',rawData appending: nil.
			].
			(#(keyword2 methodHeader2) includes: style)  ifTrue: [
				rawData _ self unSpaceAndUpShift: rawData appending: ':'.
			].
			rawData
		]
