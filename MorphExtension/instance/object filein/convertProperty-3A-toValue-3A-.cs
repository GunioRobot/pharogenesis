convertProperty: aSymbol toValue: anObject 
	"These special cases move old properties into named fields of the 
	extension"
	aSymbol == #locked
		ifTrue: [^ locked := anObject].
	aSymbol == #visible
		ifTrue: [^ visible := anObject].
	aSymbol == #sticky
		ifTrue: [^ sticky := anObject].
	aSymbol == #balloonText
		ifTrue: [^ balloonText := anObject].
	aSymbol == #balloonTextSelector
		ifTrue: [^ balloonTextSelector := anObject].
	aSymbol == #name
		ifTrue: [^ externalName := anObject].
	"*renamed*"
	aSymbol == #partsDonor
		ifTrue: [^ isPartsDonor := anObject].
	"*renamed*"
	self assureOtherProperties at: aSymbol put: anObject