initialize
	"1/25/96 sw: added references and browse items."

	InspectListYellowButtonMenu _ PopUpMenu labels: 'inspect
references
browse full
browse class'
	lines: #(1 2).
	InspectListYellowButtonMessages _ 
		#(inspectSelection referencesToSelection browseFull browseClass )

	"InspectListController initialize"