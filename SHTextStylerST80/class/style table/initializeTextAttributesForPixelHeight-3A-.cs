initializeTextAttributesForPixelHeight: aNumber
	| d element color  textStyleName  pixelHeight emphasis font textStyle attrArray |
	 
	self textAttributesByPixelHeight at: aNumber put: (d := IdentityDictionary new).
	self styleTable do: [:each |
		element := each first.
		color := each at: 2 ifAbsent:[nil].
		color:=color ifNotNil: [Color colorFrom: color].
		emphasis := each at: 3 ifAbsent:[nil].
		textStyleName := each at: 4 ifAbsent: [nil].
		pixelHeight := each at: 5 ifAbsent: [aNumber].	
		textStyleName ifNil:[pixelHeight := nil].	
		textStyle := TextStyle named: textStyleName.
		font := textStyle ifNotNil:[pixelHeight ifNotNil:[textStyle fontOfSize: pixelHeight]].
		attrArray := self attributeArrayForColor: color emphasis: emphasis font: font.
		attrArray notEmpty 
			ifTrue:[
				d at: element put: attrArray]]	
	