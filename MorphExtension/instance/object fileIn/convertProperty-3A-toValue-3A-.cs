convertProperty: aSymbol toValue: anObject 
	"These special cases move old properties into named fields of the 
	extension"
	aSymbol == #locked
		ifTrue: [^ locked _ anObject].
	aSymbol == #visible
		ifTrue: [^ visible _ anObject].
	aSymbol == #sticky
		ifTrue: [^ sticky _ anObject].
	aSymbol == #balloonText
		ifTrue: [^ balloonText _ anObject].
	aSymbol == #balloonTextSelector
		ifTrue: [^ balloonTextSelector _ anObject].
	aSymbol == #actorState
		ifTrue: [^ actorState _ anObject].
	aSymbol == #player
		ifTrue: [^ player _ anObject].
	aSymbol == #name
		ifTrue: [^ externalName _ anObject].
	"*renamed*"
	aSymbol == #partsDonor
		ifTrue: [^ isPartsDonor _ anObject].
	"*renamed*"
	self assureOtherProperties at: aSymbol put: anObject