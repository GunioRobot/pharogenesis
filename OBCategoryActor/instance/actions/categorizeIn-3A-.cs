categorizeIn: aClassOrganizer 
	"Categorize methods by looking in parent classes for a method category."
	| organizers |
	organizers := aClassOrganizer subject withAllSuperclasses collect: [:ea | ea organization].
	(aClassOrganizer listAtCategoryNamed: ClassOrganizer default) do: [:sel | | found |
		found := (organizers collect: [ :org | org categoryOfElement: sel])
			detect: [:ea | ea ~= ClassOrganizer default and: [ ea ~= nil]]
			ifNone: [].
		found ifNotNil: [aClassOrganizer classify: sel under: found]]