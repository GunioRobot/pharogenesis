categoriesDo: aBlock
	"Evaluate aBlock for each of the categories."

	categories ifNil: [^self].
	categories do: aBlock