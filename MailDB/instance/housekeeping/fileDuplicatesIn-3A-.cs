fileDuplicatesIn: categoryName
	"MailDB someInstance fileDuplicatesIn: '.duplicates.'"

	self fileAll: self findDuplicates inCategory: categoryName.
