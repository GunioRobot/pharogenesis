sortedPropertyNames
	| props |
	props _ WriteStream on: (Array new: 10).
	locked == true ifTrue:[props nextPut: #locked].
	visible == false ifTrue:[props nextPut: #visible].
	sticky == true ifTrue:[props nextPut: #sticky].
	balloonText == nil ifFalse:[props nextPut: #balloonText].
	balloonTextSelector == nil ifFalse:[props nextPut: #balloonTextSelector].
	externalName == nil ifFalse:[props nextPut: #externalName].
	isPartsDonor == true ifTrue:[props nextPut: #isPartsDonor].
	actorState == nil ifFalse:[props nextPut: #actorState].
	player == nil ifFalse:[props nextPut: #player].
	eventHandler == nil ifFalse:[props nextPut: #eventHandler].
	otherProperties == nil ifFalse:[
		otherProperties associationsDo:[:a| props nextPut: a key]].
	^props contents sort:[:s1 :s2| s1 <= s2].