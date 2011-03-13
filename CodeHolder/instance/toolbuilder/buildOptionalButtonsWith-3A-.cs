buildOptionalButtonsWith: builder

	| panelSpec buttonSpec |
	panelSpec := builder pluggablePanelSpec new.
	panelSpec children: OrderedCollection new.
	self optionalButtonPairs do:[:spec|
		buttonSpec := builder pluggableActionButtonSpec new.
		buttonSpec model: self.
		buttonSpec label: spec first.
		buttonSpec action: spec second.
		spec second == #methodHierarchy ifTrue:[
			buttonSpec color: #inheritanceButtonColor.
		]. 
		spec size > 2 ifTrue:[buttonSpec help: spec third].
		panelSpec children add: buttonSpec.
	].
	"What to show"
	panelSpec children add: (self buildCodeProvenanceButtonWith: builder).

	panelSpec layout: #horizontal. "buttons"
	^panelSpec