inspectFormsWithLabel: aLabel
	"Open a Form Dictionary inspector on the receiver, with the given label.  "

	^ DictionaryInspector openOn: self withEvalPane: true
		withLabel: aLabel
		valueViewClass: FormInspectView