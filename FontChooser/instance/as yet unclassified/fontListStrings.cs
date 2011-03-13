fontListStrings

	^fontListStrings ifNil:[
		fontListStrings := self fontList collect:[:each | each familyName]]