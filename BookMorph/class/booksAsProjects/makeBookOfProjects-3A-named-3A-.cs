makeBookOfProjects: aListOfProjects named: aString
"
BookMorph makeBookOfProjects: (Project allProjects select: [ :each | each world isMorph])
"
	| book pvm page |

	book _ self new.
	book setProperty: #transitionSpec toValue: {'silence'. #none. #none}.
	aListOfProjects do: [ :each |
		pvm _ ProjectViewMorph on: each.
		page _ PasteUpMorph new addMorph: pvm; extent: pvm extent.
		book insertPage: page pageSize: page extent
	].
	book goToPage: 1.
	book deletePageBasic.
	book setProperty: #nameOfThreadOfProjects toValue: aString.
	book removeProperty: #transitionSpec.
	book openInWorld