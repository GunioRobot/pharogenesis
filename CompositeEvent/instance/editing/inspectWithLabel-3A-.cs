inspectWithLabel: aLabel
	"Open a OrderedCollectionInspector on the receiver. Use basicInspect to get a normal (less useful) type of inspector."

	OrderedCollectionInspector openOn: self withEvalPane: true withLabel: aLabel