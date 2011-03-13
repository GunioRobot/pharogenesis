classCategoriesStartingWith: aPrefix
	"Answer a list of system class categories beginning with the given prefix.  1/18/96 sw"

	"SystemBuilder classCategoriesStartingWith: 'Files'"

	^ SystemOrganization categories select:
		[:aCat | (aCat asString findString:  aPrefix startingAt: 1) = 1]