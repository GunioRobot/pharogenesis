convertProperty: propName toValue: aValue
	"These special cases move old properties into named fields of the extension"
	propName == #locked ifTrue: [^ locked _ aValue].
	propName == #visible ifTrue: [^ visible _ aValue].
	propName == #sticky ifTrue: [^ sticky _ aValue].
	propName == #balloonText ifTrue: [^ balloonText _ aValue].
	propName == #balloonTextSelector ifTrue: [^ balloonTextSelector _ aValue].
	propName == #actorState ifTrue: [^ actorState _ aValue].
	propName == #player ifTrue: [^ player _ aValue].
	propName == #name ifTrue: [^ externalName _ aValue].  "*renamed*"
	propName == #partsDonor ifTrue: [^ isPartsDonor _ aValue].  "*renamed*"
	otherProperties == nil ifTrue: [otherProperties _ IdentityDictionary new].
	otherProperties at: propName put: aValue.
