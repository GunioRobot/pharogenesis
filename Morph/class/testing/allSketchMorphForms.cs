allSketchMorphForms
	"Answer a Set of forms of SketchMorph (sub) instances, except those 
	used as button images, ones being edited, and those with 0 extent."

	| reasonableForms form |
	reasonableForms := Set new.
	Morph allSketchMorphClasses do:
		[:cls | cls allInstances do:
			[:m | (m owner isKindOf: SketchEditorMorph orOf: IconicButton)
				ifFalse:
					[form _ m form.
					((form width > 0) and: [form height > 0]) ifTrue: [reasonableForms add: form]]]].
	^ reasonableForms