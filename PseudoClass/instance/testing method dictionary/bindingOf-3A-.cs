bindingOf: varName
	self exists ifTrue:[
		(self realClass bindingOf: varName) ifNotNilDo:[:binding| ^binding].
	].
	^Smalltalk bindingOf: varName asSymbol