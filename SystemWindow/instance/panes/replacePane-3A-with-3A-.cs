replacePane: oldPane with: newPane
	"Make newPane exactly occupy the position and extent of oldPane"

	| aLayoutFrame hadDep |
	hadDep _ model dependents includes: oldPane.
	oldPane owner replaceSubmorph: oldPane by: newPane.
	newPane
		position: oldPane position;
		extent: oldPane extent.
	aLayoutFrame _ oldPane layoutFrame.
	paneMorphs _ paneMorphs collect:
		[:each |
		each == oldPane ifTrue: [newPane] ifFalse: [each]].
	aLayoutFrame ifNotNil: [newPane layoutFrame: aLayoutFrame].
	newPane color: Color transparent.
	hadDep ifTrue: [model removeDependent: oldPane. model addDependent: newPane].

	self changed

