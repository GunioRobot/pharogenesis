allCategoriesDo: aBlock
	"Evaluate <aBlock> for all categories below me including me,
	bottom up breadth-first."

	self allSubCategoriesDo: aBlock.
	aBlock value: self