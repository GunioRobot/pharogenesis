methodsFor: categoryName stamp: changeStamp prior: indexAndOffset
	"Prior source link ignored when filing in."
	^ ClassCategoryReader new setClass: self
				category: categoryName asSymbol
				changeStamp: changeStamp
