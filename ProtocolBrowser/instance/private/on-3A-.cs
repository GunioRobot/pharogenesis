on: aClass 
	"Initialize with the entire protocol for the class, aClass."
	self initListFrom: aClass allSelectors asSortedCollection
		highlighting: aClass