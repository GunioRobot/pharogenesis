addPackagesTo: window at: fractions plus: verticalOffset
	"Add the list for packages, and answer the verticalOffset plus the height added"

	| divider listMorph |
	listMorph _ self buildMorphicPackagesList.
	listMorph borderWidth: 0.
	divider _ BorderedSubpaneDividerMorph forBottomEdge.
	Preferences alternativeWindowLook ifTrue:[
		divider extent: 4@4; color: Color transparent; borderColor: #raised; borderWidth: 2.
	].
	window 
		addMorph: listMorph
		
	