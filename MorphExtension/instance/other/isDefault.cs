isDefault
	"Return true if the receiver is a default and can be omitted"
	locked == true ifTrue:[^false].
	visible == false ifTrue:[^false].
	sticky == true ifTrue:[^false].
	balloonText == nil ifFalse:[^false].
	balloonTextSelector == nil ifFalse:[^false].
	externalName == nil ifFalse:[^false].
	isPartsDonor == true ifTrue:[^false].
	actorState == nil ifFalse:[^false].
	player == nil ifFalse:[^false].
	eventHandler == nil ifFalse:[^false].
	otherProperties == nil ifFalse:[otherProperties size > 0 ifTrue:[^false]].
	^true