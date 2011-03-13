veryDeepInner: deepCopier 
	"Copy all of my instance variables.
	Some otherProperties need to be not copied at all, but shared. Their names are given by copyWeakly.
	Some otherProperties should not be copied or shared. Their names are given by propertyNamesNotCopied.
	This is special code for the dictionary. See DeepCopier, and veryDeepFixupWith:."

	| namesOfWeaklyCopiedProperties weaklyCopiedValues |
	super veryDeepInner: deepCopier.
	locked _ locked veryDeepCopyWith: deepCopier.
	visible _ visible veryDeepCopyWith: deepCopier.
	sticky _ sticky veryDeepCopyWith: deepCopier.
	balloonText _ balloonText veryDeepCopyWith: deepCopier.
	balloonTextSelector _ balloonTextSelector veryDeepCopyWith: deepCopier.
	externalName _ externalName veryDeepCopyWith: deepCopier.
	isPartsDonor _ isPartsDonor veryDeepCopyWith: deepCopier.
	actorState _ actorState veryDeepCopyWith: deepCopier.
	player _ player veryDeepCopyWith: deepCopier.		"Do copy the player of this morph"
	eventHandler _ eventHandler veryDeepCopyWith: deepCopier. 	"has its own restrictions"

	otherProperties ifNil: [ ^self ].

	otherProperties := otherProperties copy.
	self propertyNamesNotCopied do: [ :propName | otherProperties removeKey: propName ifAbsent: [] ].

	namesOfWeaklyCopiedProperties _ self copyWeakly.
	weaklyCopiedValues _ namesOfWeaklyCopiedProperties collect: [  :propName | otherProperties removeKey: propName ifAbsent: [] ].

	"Now copy all the others."
	otherProperties := otherProperties veryDeepCopyWith: deepCopier.

	"And replace the weak ones."
	namesOfWeaklyCopiedProperties with: weaklyCopiedValues do: [ :name :value | value ifNotNil: [ otherProperties at: name put: value ]].
