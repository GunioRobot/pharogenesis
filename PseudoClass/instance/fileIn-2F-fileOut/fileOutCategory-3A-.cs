fileOutCategory: categoryName
	| f |
	f := (FileStream newFileNamed: self name,'-',categoryName,'.st').
	self fileOutMethods: (self organization listAtCategoryNamed: categoryName)
			on: f.
	f close
