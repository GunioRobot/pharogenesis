allSubCategoriesDo: aBlock
	"Evaluate <aBlock> for all categories below me NOT including me,
	bottom up breadth-first."

	subCategories ifNil: [^self].
	subCategories do: [:sub |
		sub allSubCategoriesDo: aBlock.
		aBlock value: sub]