inspectFormsWithLabel: aLabel
	"Open a Form Dictionary inspector on the receiver, with the given label.  "

	^ DictionaryInspector openOn: self withEvalPane: false
		withLabel: aLabel
		valueViewClass: FormInspectView