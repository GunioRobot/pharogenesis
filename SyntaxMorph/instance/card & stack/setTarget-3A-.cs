setTarget: aPlayer
	"Find my UpdatingStringMorph and set its getSelector, putSelector, and target"

	| updatingString |
	(updatingString := self readOut) ifNil: [^ self].
	updatingString putSelector: (Utilities setterSelectorFor: self knownName).
	updatingString getSelector: (Utilities getterSelectorFor: self knownName).
	updatingString target: aPlayer. 