removeMacAppClassesFromSystem
	"Remove all those undesired MacApp classes from the image.  1/18/96 sw"

	"SystemBuilder removeMacAppClassesFromSystem"

	(self classCategoriesStartingWith: 'MacApp') do:
		[:aCategory |
			SystemOrganization removeSystemCategory: aCategory]