categoryWrapperList
	"Create the wrapper list for the hierarchical list.
	We sort the categories by name but ensure that 'Squeak versions'
	is first if it exists."
	 
	| list first |
	list := (((model categories select:[:each | each parent == nil]) asArray 
		sort:[:c1 :c2 | c1 name <= c2 name])).
	first := list detect:[:any | any name = 'Squeak versions'] ifNone:[nil].
	first ifNotNil:[
		list := list copyWithout: first.
		list := {first}, list].
	^list collect:[:cat | SMCategoryWrapper with: cat model: self].