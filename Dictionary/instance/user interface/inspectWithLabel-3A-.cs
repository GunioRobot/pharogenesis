inspectWithLabel: aLabel
	"Open a DictionaryInspector on the receiver. Use basicInspect to get a normal (less useful) type of inspector."

	DictionaryInspector openOn: self withEvalPane: true withLabel: aLabel