packageMenu: aMenu
	"Answer a Menu of operations on class packages to be 
	displayed when the operate menu button is pressed."

	^aMenu
			labels: 'find class...\recent classes...\reorganize\update' withCRs
			lines: #(2)
			selections: #(#findClass #recent #editSystemCategories #updatePackages)