methodsFor: categoryName 
	"Answer a ClassCategoryReader for compiling the messages in the category, categoryName, of the receiver."

	^ ClassCategoryReader new setClass: self category: categoryName asSymbol

	"(False methodsFor: 'logical operations') inspect"